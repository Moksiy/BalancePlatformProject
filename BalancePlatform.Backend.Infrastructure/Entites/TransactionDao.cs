
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Операции с валютой
    /// </summary>
    public class TransactionDao : EntityWithIdDao<long>
    {
        /// <summary>
        /// Ид пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Значение 
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Зачисление?
        /// </summary>
        public bool IsIncome { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип валюты
        /// </summary>
        public byte CurrencyTypeId { get; set; }
    }
}
