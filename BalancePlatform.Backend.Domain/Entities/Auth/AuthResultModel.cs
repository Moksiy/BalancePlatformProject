using BalancePlatform.Backend.Domain.Entities.Base;
using BalancePlatform.Backend.Domain.Entities.Roles;
using BalancePlatform.Backend.Domain.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Результат аутентификации для веб интерфейса
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthResultModel : BaseResult
    {
        /// <summary>
        /// Токен
        /// </summary>
        [Display(Name = "Токен")]
        public string Token { get; set; }

        public UserForWeb User { get; set; }
    }
}
