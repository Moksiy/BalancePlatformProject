using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Profiles
{
    /// <summary>
    /// Данные профиля пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class ProfileData : IEntity
    {
        /// <summary>
        /// Добавление фото из галереи
        /// </summary>
        [Display(Name = "Добавление фото из галереи")]
        public bool GalleryAccess { get; set; }
    }
}