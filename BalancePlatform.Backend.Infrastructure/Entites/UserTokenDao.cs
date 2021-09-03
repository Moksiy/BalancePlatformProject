using System;
using System.ComponentModel.DataAnnotations;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Токен авторизации пользователя
    /// </summary>
    public class UserTokenDao : EntityDao
    {
        /// <summary>
        /// Токен
        /// </summary>
        [MaxLength(256)]
        public string Token { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }
        /// <summary>
        /// Дата окончания действия токена
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
