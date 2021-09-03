using BalancePlatform.Backend.Common.Base.Extensions;
using BalancePlatform.Backend.Common.Base.Helpers;
using BalancePlatform.Backend.Domain.Entities.Auth;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.WebApi.Controllers
{
    /// <summary>
    /// OData Web Api контроллер аутентификации
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        private readonly IAuthService _authService;

        /// <summary>
        /// OData Web Api контроллер аутентификации
        /// </summary>
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;

            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _authService = kernel.Get<IAuthService>();
        }

        [HttpPost]
        public ActionResult Post(AuthModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var authResult = _authService.Auth(model);
                return Ok(authResult);
            }
            catch (BaseException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost("Login")]
        public ActionResult AuthByСredentials(AuthModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var authResult = _authService.AuthByСredentials(model);
                if (authResult.ErrorCode == 0)
                {
                    return Ok(authResult);
                }
                else
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, authResult);
                }
            }
            catch (BaseException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost("LoginByToken")]
        public ActionResult AuthByToken(TokenData token)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var authResult = _authService.AuthByToken(token);
                return Ok(authResult);
            }
            catch (BaseException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        #region ВРЕМЕННО
        [HttpGet("CreateHash")]
        public string GetHash(string password)
        {
            var salt = "bDz<!%#u8&";//Md5Helper.CalculateMd5Hash(Guid.NewGuid().ToString()).Substring(0, 8);
            var passwordHash = Md5Helper.CalculateMd5Hash(password + salt);//Md5Helper.CalculateMd5Hash(salt + "/" + password + "\\" + salt);
            return passwordHash;
        }
        #endregion
    }
}
