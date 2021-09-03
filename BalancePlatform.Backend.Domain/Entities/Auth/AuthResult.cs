using BalancePlatform.Backend.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Результат аутентификации
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthResult : BaseResult
    {
        /// <summary>
        /// Данные токена
        /// </summary>
        [Display(Name = "Данные токена")]
        public TokenData Data { get; set; }
    }
}
