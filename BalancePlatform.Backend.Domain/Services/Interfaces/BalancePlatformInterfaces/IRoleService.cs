using BalancePlatform.Backend.Domain.Entities.Roles;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System.Linq;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с ролями пользователей
    /// </summary>
    public interface IRoleService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса ролей пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса ролей пользователей</returns>
        IQueryable<Role> GetQueryable();
    }
}
