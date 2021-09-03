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
    /// Информация о пользователе
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserInfo : IEntityWithId<int>
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
        public string Title { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        [Display(Name = "Ссылка на фото")]
        [DataMember]
        public string ImgUrl { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        [Display(Name = "Электронная почта")]
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        [Display(Name = "Номер телефона")]
        [DataMember]
        public string Phone { get; set; }
        /// <summary>
        /// Номер в рейтинге
        /// </summary>
        [Display(Name = "Номер в рейтинге")]
        [DataMember]
        public int PlaceOnTop { get; set; }

    }
}
