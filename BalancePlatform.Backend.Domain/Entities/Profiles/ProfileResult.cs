using BalancePlatform.Backend.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Profiles
{
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    [DataContract]
    [Serializable]
    public class ProfileResult : BaseResult
    {
        /// <summary>
        /// Данные профиля пользователя
        /// </summary>
        [Display(Name = "Данные профиля")]
        public ProfileData Data { get; set; }
    }
}
