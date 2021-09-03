using BalancePlatform.Backend.Domain.Entities.Auth;
using BalancePlatform.Backend.Domain.Entities.Base;
using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Interfaces.BalancePlatformInterfaces
{
    /// <summary>
    /// Интерфейс сервиса аутентификации
    /// </summary>
    public interface IAuthService : IBaseService
    {
        /// <summary>
        /// Производит аутентификацию пользователя для мобильного приложения
        /// </summary>
        /// <param name="model">Данные аутентификации</param>
        /// <returns>Результат аутентификации</returns>
        BaseResult Auth(AuthModel model);

        /// <summary>
        /// Производит аутентификацию пользователя для веб интерфейса
        /// </summary>
        /// <param name="model">Данные аутентификации</param>
        /// <returns>Результат аутентификации</returns>
        AuthResultModel AuthByСredentials(AuthModel model);

        /// <summary>
        /// Производит аутентификацию пользователя по токену для веб интерфейса
        /// </summary>
        /// <param name="token">Токен</param>
        /// <returns>Результат аутентификации</returns>
        AuthResultModel AuthByToken(TokenData token);
    }
}
