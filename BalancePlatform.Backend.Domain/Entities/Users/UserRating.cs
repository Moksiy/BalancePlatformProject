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
    /// Рейтинг пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class UserRating : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        [Display(Name = "Ссылка на фото")]
        [DataMember]
        public string ImgUrl { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Display(Name = "Имя пользователя")]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        [Display(Name = "Тип")]
        [DataMember]
        public string Type { get; set; }

        /// <summary>
        /// Место в рейтинге
        /// </summary>
        [Display(Name = "Место в рейтинге")]
        [DataMember]
        public int PlaceOnTop { get; set; }

        /// <summary>
        /// Целевой счет
        /// </summary>
        [Display(Name = "Целевой счет")]
        [DataMember]
        public int TotalScore { get; set; }

        /// <summary>
        /// Текущий счет
        /// </summary>
        [Display(Name = "Текущий счет")]
        [DataMember]
        public int Score { get; set; }
    }
}
