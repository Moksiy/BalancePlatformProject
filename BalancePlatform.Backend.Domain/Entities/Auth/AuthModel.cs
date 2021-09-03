using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Auth
{
    /// <summary>
    /// Данные для аутентификации
    /// </summary>
    [DataContract]
    [Serializable]
    public class AuthModel : IEntity
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [DataMember(IsRequired = true)]
        public string Login { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Display(Name = "Пароль")]
        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}
