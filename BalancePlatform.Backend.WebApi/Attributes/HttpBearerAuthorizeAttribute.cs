using BalancePlatform.Backend.Common.Base.Contexts;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HttpBearerAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context != null)
            {
                if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any()) return;

                Microsoft.Extensions.Primitives.StringValues authTokens;
                context.HttpContext.Request.Headers.TryGetValue("Authorization", out authTokens);

                string _token = null;
                var authToken = authTokens.FirstOrDefault();
                if (authToken != null)
                {
                    _token = authToken.Contains(" ") ? authToken.Split(" ").LastOrDefault() : authToken;
                }

                if (_token != null)
                {
                    string token = _token;
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        bool isValidToken = false;

                        IKernel kernel = new StandardKernel(new BalancePlatformModule());

                        var userService = kernel.Get<IUserService>();

                        var user = userService.GetUserByToken(token);
                        if (user != null && user.IsActive)
                        {
                            ServerContext.UserId = user.Id;
                            ServerContext.UserRoleId = user.RoleId;
                            ServerContext.UserName = user.UserName;
                            isValidToken = true;
                        }

                        if (isValidToken)
                        {
                            context.HttpContext.Response.Headers.Add("authToken", token);
                            context.HttpContext.Response.Headers.Add("AuthStatus", "Authorized");

                            context.HttpContext.Response.Headers.Add("storeAccessiblity", "Authorized");

                            return;
                        }
                        else
                        {
                            context.HttpContext.Response.Headers.Add("authToken", token);
                            context.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                            context.Result = new JsonResult("NotAuthorized")
                            {
                                Value = new
                                {
                                    Status = "Error",
                                    Message = "Invalid Token"
                                },
                            };
                        }
                    }
                }
                else
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                    context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide Authorization";
                    context.Result = new JsonResult("Please Provide Authorization")
                    {
                        Value = new
                        {
                            ErrorCode = (int)HttpStatusCode.ExpectationFailed,
                            //Status = "Error",
                            ErrorText = "Please Provide Authorization"
                        },
                    };
                }
            }
        }
    }
}
