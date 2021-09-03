using BalancePlatform.Backend.Infrastructure.Contexts;
using BalancePlatform.Backend.Infrastructure.Entites;
using BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Infrastructure.Repositories.Implementations.BaseImplementations
{
    /// <summary>
    /// Базовый репозиторий работы с сущностями с идентификатором
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора сущности</typeparam>
    public class EntityWithIdRepository<T, TKey> : EntityRepository<T>, IEntityWithIdRepository<T, TKey> where T : EntityWithIdDao<TKey>
    {
        /// <summary>
        /// Базовый репозиторий работы с сущностями с идентификатором
        /// </summary>
        /// <param name="context">Контекст работы с БД</param>
        public EntityWithIdRepository(BaseDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Возвращает объект по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Объект</returns>
        public T GetById(TKey id)
        {
            return Context.Set<T>().Find(id);
        }

        /// <summary>
        /// Возвращает объект по его идентификатору (только из БД)
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Объект</returns>
        public T GetByIdFromDatabase(TKey id)
        {
            var entity = Context.Set<T>().Local.FirstOrDefault(x => x.Id.Equals(id));
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Detached;
            }
            return Context.Set<T>().Find(id);
        }
    }
}
