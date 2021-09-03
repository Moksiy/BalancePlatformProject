using System;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class OrderDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Ид юзера
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public UserDao User { get; set; }

        /// <summary>
        /// Ид товара
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Товар
        /// </summary>
        public ProductDao Product { get; set; }

        /// <summary>
        /// Дата и время покупки
        /// </summary>
        public DateTime DateTime { get; set; }
    }
}
