
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Бейдж
    /// </summary>
    public class BadgeDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Очки рейтинга
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public int SpentCurrency { get; set; }

    }
}
