using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Данные токена
    /// </summary>
    [DataContract]
    [Serializable]
    public class TokenData : IEntity
    {
        /// <summary>
        /// Токен авторизации
        /// </summary>
        [Display(Name = "Токен авторизации")]
        public string Token { get; set; }
    }
}
