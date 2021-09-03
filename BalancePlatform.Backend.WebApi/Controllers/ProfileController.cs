using BalancePlatform.Backend.Common.Base.Extensions;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.WebApi.Attributes;
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
    /// OData Web Api контроллер работы с профилями пользователей
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        private readonly IUserService _userService;

        /// <summary>
        /// OData Web Api контроллер работы с профилями пользователей
        /// </summary>
        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;

            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _userService = kernel.Get<IUserService>();
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var profileResult = _userService.GetProfileResult();
                return Ok(profileResult);
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
    }
}
