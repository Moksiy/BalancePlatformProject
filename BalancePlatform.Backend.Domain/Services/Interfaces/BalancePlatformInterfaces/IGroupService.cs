using BalancePlatform.Backend.Domain.Entities.Groups;
using BalancePlatform.Backend.Domain.Entities.GroupsRatings;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с группами
    /// </summary>
    public interface IGroupService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса групп
        /// </summary>
        /// <returns>Интерфейс для запроса ролей пользователей</returns>
        IQueryable<Group> GetQueryable();

        /// <summary>
        /// Получить информацию по группам
        /// </summary>
        /// <returns></returns>
        List<GroupRating> GetGroupsList();
    }
}
