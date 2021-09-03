
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Группа
    /// </summary>
    public class GroupDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Счет группы
        /// </summary>
        public int GroupScore { get; set; }

        /// <summary>
        /// Ид одмена
        /// </summary>
        public int AdminId { get; set; }

        /// <summary>
        /// Админ
        /// </summary>
        public UserDao Admin { get; set; }

        /// <summary>
        /// Картинка
        /// </summary>
        public string ImageUrl { get; set; }
    }
}