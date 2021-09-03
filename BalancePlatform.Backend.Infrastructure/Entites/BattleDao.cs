
using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Вызов
    /// </summary>
    public class BattleDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата конца
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Группа победитель
        /// </summary>
        public int? WinnerGroupId { get; set; }

        /// <summary>
        /// Группа победитель
        /// </summary>
        public GroupDao WinnerGroup { get; set; }
        
        /// <summary>
        /// Битва активна?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
