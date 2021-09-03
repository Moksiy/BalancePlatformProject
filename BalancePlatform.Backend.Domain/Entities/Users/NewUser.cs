using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [DataContract]
    [Serializable]
    public class NewUser : IEntity
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Display(Name = "Логин")]
        [DataMember(IsRequired = true)]
        public string Login { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Display(Name = "Имя пользователя")]
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        [DataMember(IsRequired = true)]
        public string Email { get; set; }
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [Display(Name = "Id роли")]
        [DataMember(IsRequired = true)]
        public int RoleId { get; set; }
    }
}
