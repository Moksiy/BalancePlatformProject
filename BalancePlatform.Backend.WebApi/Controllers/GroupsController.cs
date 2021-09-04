using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.GroupsRatings;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
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
    /// OData Web Api контроллер работы с группами
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly ILogger<GroupsController> _logger;

        private readonly IGroupService _groupService;

        private readonly IMapper _mapper;

        /// <summary>
        /// OData Web Api контроллер работы с магазином
        /// </summary>
        public GroupsController(ILogger<GroupsController> logger)
        {
            _logger = logger;

            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _groupService = kernel.Get<IGroupService>();

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Получаем список пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public List<GroupRating> GetGroupsRating()
        {
            try
            {
                return _groupService.GetGroupsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
