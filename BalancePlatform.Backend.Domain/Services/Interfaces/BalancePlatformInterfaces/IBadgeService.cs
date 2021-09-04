
using System.Linq;
using BalancePlatform.Backend.Domain.Entities.Branches;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    public interface IBadgeService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для бейджей
        /// </summary>
        /// <returns></returns>
        IQueryable<Badge> GetQueryable();
    } 
}
