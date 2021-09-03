using BalancePlatform.Backend.Common.Base.Entities;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Базовый абстрактный класс для всех DAO сущностей с идентификатором
    /// </summary>
    public abstract class EntityWithIdDao<TKey> : EntityDao, IEntityWithId<TKey>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public TKey Id { get; set; }
    }
}
