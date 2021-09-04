using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.GroupsRatings
{
    /// <summary>
    /// Рейтинг группы
    /// </summary>
    [DataContract]
    [Serializable]
    public class GroupRating : IEntityWithId<int>
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
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Место в рейтинге
        /// </summary>
        [Display(Name = "Место в рейтинге")]
        [DataMember]
        public int PlaceOnTop { get; set; }

        /// <summary>
        /// Количество побед
        /// </summary>
        [Display(Name = "Количество побед")]
        [DataMember]
        public int Wins { get; set; }

        /// <summary>
        /// Количество ничьих
        /// </summary>
        [Display(Name = "Количество ничьих")]
        [DataMember]
        public int Draws { get; set; }

        /// <summary>
        /// Количество поражений
        /// </summary>
        [Display(Name = "Количество поражений")]
        [DataMember]
        public int Defeats { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [DataMember]
        public int UsersCount { get; set; }
    }
}
