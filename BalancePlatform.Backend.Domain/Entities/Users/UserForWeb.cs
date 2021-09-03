using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Users
{
    /// <summary>
    /// Пользователь для веб интерфейса
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserForWeb : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Display(Name = "Имя пользователя")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        [Display(Name = "Роль пользователя")]
        [DataMember]
        public List<string> Roles { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        [Display(Name = "Ссылка на фото")]
        [DataMember]
        public string ImageUrl { get; set; }
    }
}
