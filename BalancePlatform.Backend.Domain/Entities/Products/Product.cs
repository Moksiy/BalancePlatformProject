using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Entities.ShopItems
{
    /// <summary>
    /// Бонус из магазина
    /// </summary>
    [DataContract]
    [Serializable]
    public class Product : IEntityWithId<int>
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
        /// Цена
        /// </summary>
        [Display(Name = "Цена")]
        [DataMember]
        public int Price { get; set; }

        [Display(Name = "Цена")]
        [DataMember]
        public bool CanBy { get; set; } 
    }
}
