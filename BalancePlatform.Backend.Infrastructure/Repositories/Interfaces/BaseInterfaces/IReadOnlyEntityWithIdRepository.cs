using BalancePlatform.Backend.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces
{
    /// <summary>
    /// Интерфейс базового репозитория работы с сущностями с идентификаторами в режиме "только чтение"
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора сущности</typeparam>
    public interface IReadOnlyEntityWithIdRepository<T, TKey> : IReadOnlyEntityRepository<T> where T : EntityWithIdDao<TKey>
    {
        /// <summary>
        /// Возвращает объект по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <returns>Объект</returns>
        T GetById(TKey id);
    }
}
