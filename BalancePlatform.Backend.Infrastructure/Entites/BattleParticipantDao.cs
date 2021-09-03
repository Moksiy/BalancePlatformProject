
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Участники вызова
    /// </summary>
    public class BattleParticipantDao : EntityDao
    {
        /// <summary>
        /// ID вызова
        /// </summary>
        public int BattleId { get; set; }

        /// <summary>
        /// Вызов
        /// </summary>
        public BattleDao Battle { get; set; }
        
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
        
    }
}
