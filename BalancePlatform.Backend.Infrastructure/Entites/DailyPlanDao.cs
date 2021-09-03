
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Минимальный план по очкам на день
    /// </summary>
    public class DailyPlanDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// ID Пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Минимум очков, которые необходимо набрать за день
        /// </summary>
        public int MinScore { get; set; }

        /// <summary>
        /// Дата плана
        /// </summary>
        public DateTime Date { get; set; }
    }
}
