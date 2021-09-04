using BalancePlatform.Backend.Domain.Entities.ShopItems;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с магазином
    /// </summary>
    /// 
    public interface IShopService : IBaseService
    {       
        /// <summary>
        /// Возвращает интерфейс для запроса товаров магазина
        /// </summary>
        /// <returns>Интерфейс для запроса ролей пользователей</returns>
        IQueryable<Product> GetQueryable();
    }
}
