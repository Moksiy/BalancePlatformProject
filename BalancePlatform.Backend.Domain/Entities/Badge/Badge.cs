
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using BalancePlatform.Backend.Common.Base.Entities;

namespace BalancePlatform.Backend.Domain.Entities.Branches
{
    [DataContract]
    [Serializable]
    public class Badge:IEntityWithId<int>
    {
        [Display(Name = "Id")]
        [DataMember]
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        [Display(Name = "Ссылка на фото")]
        [DataMember]
        public string ImgUrl { get; set; }

        [Display(Name = "Описание")]
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Баллы в рейтинга
        /// </summary>
        [Display(Name = "Баллы в рейтинга")]
        [DataMember]
        public int Score { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        [Display(Name = "Валюта")]
        [DataMember]
        public int SpentCurrency { get; set; }
    }
}
