using AutoMapper;
using BalancePlatform.Backend.Domain.Entities.ShopItems;
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
    /// Сервис работы с магазином
    /// </summary>
    public class ShopService : BaseService, IShopService
    {
        private readonly BalancePlatformContext _balancePlatformContext;

        private readonly IEntityWithIdRepository<ProductDao, int> _shopRepository;

        private readonly IMapper _mapper;

        /// <summary>
        /// Сервис работы с магазином
        /// </summary>
        public ShopService()
        {
            IKernel kernel = new StandardKernel(new BalancePlatformModule());

            _balancePlatformContext = kernel.Get<BalancePlatformContext>();

            _shopRepository = kernel.Get<IEntityWithIdRepository<ProductDao, int>>(new ConstructorArgument("context", _balancePlatformContext));
            
            _mapper = kernel.Get<IMapper>();
        }

        /// <summary>
        /// Возвращает интерфейс для запроса товаров магазина
        /// </summary>
        /// <returns>Интерфейс для запроса товаров магазина</returns>
        public IQueryable<Product> GetQueryable()
        {
            try
            {
                var shopQueryable = _shopRepository.GetQueryable();
                return _mapper.ProjectTo<Product>(shopQueryable);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
