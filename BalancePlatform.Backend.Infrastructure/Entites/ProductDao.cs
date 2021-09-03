
namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Товар
    /// </summary>
    public class ProductDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Ссылка на фото
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }
    }
}
