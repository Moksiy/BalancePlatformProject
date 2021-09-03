using BalancePlatform.Backend.Common.Base.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BalancePlatform.Backend.Domain.Entities.Base
{
    /// <summary>
    /// Результат аутентификации
    /// </summary>
    [DataContract]
    [Serializable]
    public class BaseResult : IEntity
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        [Display(Name = "Код ошибки")]
        public int ErrorCode { get; set; }
        /// <summary>
        /// Текст ошибки
        /// </summary>
        [Display(Name = "Текст ошибки")]
        public string ErrorText { get; set; }
    }
}
