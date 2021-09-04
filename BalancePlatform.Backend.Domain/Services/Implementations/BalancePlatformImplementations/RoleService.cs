using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.Roles;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Implementations.BaseImplementations;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Entites;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Implementations.BalancePlatformImplementations
{
    /// <summary>
    /// Сервис работы с ролями пользователей
    /// </summary>
    public class RoleService : BaseService, IRoleService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<RoleDao, int> _roleRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с ролями пользователей
        /// </summary>
        public RoleService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _roleRepository = kernel.Get<IEntityWithIdRepository<RoleDao, int>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса ролей пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса ролей пользователей</returns>
        public IQueryable<Role> GetQueryable()
        {
            var roleQueryable = _roleRepository.GetQueryable();
            return _mapper.ProjectTo<Role>(roleQueryable);
        }
    }
}
