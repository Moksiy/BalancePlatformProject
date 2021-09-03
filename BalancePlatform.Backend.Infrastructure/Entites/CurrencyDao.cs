
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Валюта пользователя
    /// </summary>
    public class CurrencyDao : EntityDao
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public int Value { get; set; }
    }
}
