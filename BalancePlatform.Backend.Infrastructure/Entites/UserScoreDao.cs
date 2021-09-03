namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Счет пользователя
    /// </summary>
    public class UserScoreDao : EntityDao
    {
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Счет пользователя
        /// </summary>
        public int Score { get; set; }
    }
}