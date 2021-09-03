
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Бейджи пользователя
    /// </summary>
    public class UserBadgeDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Ид юзера
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Польлователь
        /// </summary>
        public UserDao User { get; set; }
        
        /// <summary>
        /// Ид бейджа
        /// </summary>
        public int BadgeId { get; set; }

        /// <summary>
        /// Бейдж
        /// </summary>
        public BadgeDao Badge { get; set; }

    }
}
