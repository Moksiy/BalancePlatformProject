
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
        /// Стоимость
        /// </summary>
        public int Cost { get; set; }

    }
}
