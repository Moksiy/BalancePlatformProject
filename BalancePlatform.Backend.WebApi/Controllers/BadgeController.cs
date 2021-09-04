
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BalancePlatform.Backend.Common.Base.Extensions;
using BalancePlatform.Backend.Domain.Entities.Branches;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ninject;

namespace BalancePlatform.Backend.WebApi.Controllers
{
    /// <summary>
    /// OData Web Api контроллер работы с магазином
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BadgeController : ControllerBase
    {
        private readonly ILogger<BadgeController> _logger;

        private readonly IBadgeService _badgeService;

        private readonly IMapper _mapper;

        /// <summary>
        /// OData Web Api контроллер работы с магазином
        /// </summary>
        public BadgeController(ILogger<BadgeController> logger)
        {
            _logger = logger;

            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _badgeService = kernel.Get<IBadgeService>();

            _mapper = kernel.Get<IMapper>();
        }


        /// <summary>
        /// Получить список товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet("badges")]
        public List<Badge> GetProducts()
        {
            try
            {
                return _badgeService.GetQueryable().ToList();
            }
            catch (BaseException ex)
            {
                throw ex;
            }
        }
    }
}