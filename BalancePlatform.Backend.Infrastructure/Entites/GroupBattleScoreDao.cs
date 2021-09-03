
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Счет группы за вызов
    /// </summary>
    class GroupBattleScoreDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// ID Вызова
        /// </summary>
        public int BattleId { get; set; }

        /// <summary>
        /// Вызов
        /// </summary>
        public BattleDao Battle { get; set; }
        
        /// <summary>
        /// ID группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Группа
        /// </summary>
        public GroupDao Group { get; set; }

        /// <summary>
        /// Счет группы
        /// </summary>
        public int Score { get; set; }

    }
}
