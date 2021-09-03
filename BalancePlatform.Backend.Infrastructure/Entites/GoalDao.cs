
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Цель
    /// </summary>
    public class GoalDao :EntityWithIdDao<int>
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
        /// Активен?
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Дата дедлайна цели
        /// </summary>
        public DateTime DateDeadline { get; set; }

        /// <summary>
        /// Ценность
        /// </summary>
        public int Score { get; set; }
    }
}
