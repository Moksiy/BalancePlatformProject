using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [DataContract]
    [Serializable]
    public class User : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [DataMember]
        public string Login { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Display(Name = "Имя пользователя")]
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [Display(Name = "Id роли")]
        [DataMember]
        public int RoleId { get; set; }
        /// <summary>
        /// Активен?
        /// </summary>
        [Display(Name = "Активен?")]
        [DataMember]
        public bool IsActive { get; set; }        
    }
}