using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using BalancePlatform.Backend.Common.Base.Entities;

namespace BalancePlatform.Backend.Domain.Entities.Groups
{
    /// <summary>
    /// Группы
    /// </summary>
    [DataContract]
    [Serializable]
    public class Group : IEntityWithId<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Display(Name = "Id")]
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Display(Name = "Описание")]
        [DataMember]
        public string Description { get; set; }

    }
}