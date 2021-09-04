using System;
using System.Linq;
using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.Branches;
using BalancePlatform.Backend.Domain.Ninject;
using BalancePlatform.Backend.Domain.Services.Implementations.BaseImplementations;
using BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces;
using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Entites;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Ninject;
using Ninject.Parameters;

namespace BalancePlatform.Backend.Domain.Services.Implementations.BalancePlatformImplementations
{
    public class BadgeService : BaseService, IBadgeService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<BadgeDao, int> _shopRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с магазином
        /// </summary>
        public BadgeService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _shopRepository = kernel.Get<IEntityWithIdRepository<BadgeDao, int>>(new ConstructorArgument("context", _balancePlatformContext));

            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса товаров магазина
        /// </summary>
        /// <returns>Интерфейс для запроса товаров магазина</returns>
        public IQueryable<Badge> GetQueryable()
        {
            try
            {
                var shopQueryable = _shopRepository.GetQueryable();
                return _mapper.ProjectTo<Badge>(shopQueryable);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
