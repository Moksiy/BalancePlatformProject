using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Roles
{
    /// <summary>
    /// Роль пользователь
    /// </summary>
    [DataContract]
    [Serializable]
    public class Role : IEntityWithId<int>
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
        /// Активна?
        /// </summary>
        [Display(Name = "Активна?")]
        [DataMember]
        public bool IsActive { get; set; }
    }
}
