
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Заявка на вызов
    /// </summary>
    public class BattleRequestDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Группа 1 (атакует)
        /// </summary>
        public int AttackGroupId { get; set; }

        /// <summary>
        /// Группа 2 (защищается)
        /// </summary>
        public GroupDao AttackGroup { get; set; }

        /// <summary>
        /// Группа 2 (защищается)
        /// </summary>
        public int DefenseGroupId { get; set; }

        /// <summary>
        /// Группа 2 (защищается)
        /// </summary>
        public GroupDao DefenseGroup { get; set; }

        /// <summary>
        /// Дата создания запроса на вызов
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Статус запроса на вызов
        /// </summary>
        public int RequestStatusId { get; set; }

        /// <summary>
        /// Активна?
        /// </summary>
        public bool IsActive { get; set; }

    }
}
