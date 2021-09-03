using BalancePlatform.Backend.Common.Base.Repositories;
using BalancePlatform.Backend.Infrastructure.Entites;
using System.Linq;

namespace BalancePlatform.Backend.Infrastructure.Repositories.Interfaces.BaseInterfaces
{
    /// <summary>
    /// Интерфейс базового репозитория работы с сущностями в режиме "только чтение"
    /// </summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IReadOnlyEntityRepository<T> : IRepository where T : EntityDao
    {
        /// <summary>
        /// Возвращает интерфейс для запроса
        /// </summary>
        /// <returns>Интерфейс для запроса</returns>
        IQueryable<T> GetQueryable();
    }
}
