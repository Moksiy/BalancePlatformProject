using BalancePlatform.Backend.Domain.Entities.Branches;
using BalancePlatform.Backend.Domain.Entities.Users;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    /// <summary>
    /// Интерфейс сервиса работы с пользователями для веб интерфейса
    /// </summary>
    public interface IUserForWebService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса пользователей для веб интерфейса
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей для веб интерфейса</returns>
        IQueryable<UserForWeb> GetQueryable();

        /// <summary>
        /// Получить список пользователей с из позицией в топе
        /// </summary>
        /// <returns></returns>
        List<UserInfo> GetUserList();

        /// <summary>
        /// Получить профиль пользователя
        /// </summary>
        /// <returns></returns>
        UserProfile GetUserProfile(int id);

        /// <summary>
        /// Получить рейтинг пользователей
        /// </summary>
        /// <returns></returns>
        List<UserRating> GetUserRatings();

        /// <summary>
        /// Получить список беджей пользователя
        /// </summary>
        /// <returns></returns>
        List<Badge> GetUserBadges(int id);
    }
}
