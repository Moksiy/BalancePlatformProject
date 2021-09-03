using BalancePlatform.Backend.Domain.Entities.Base;
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
    /// Интерфейс сервиса работы с пользователями
    /// </summary>
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// Возвращает интерфейс для запроса пользователей
        /// </summary>
        /// <returns>Интерфейс для запроса пользователей</returns>
        IQueryable<User> GetQueryable();

        /// <summary>
        /// Создаёт пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        void Create(NewUser user);

        /// <summary>
        /// Ищет пользователя по его токену
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Пользователь</returns>
        User GetUserByToken(string token);

        /// <summary>
        /// Возвращает профиль авторизованного пользователя
        /// </summary>
        /// <returns>Профиль авторизованного пользователя</returns>
        BaseResult GetProfileResult();
    }
}
