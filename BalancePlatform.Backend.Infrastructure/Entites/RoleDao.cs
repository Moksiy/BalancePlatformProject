
using System.ComponentModel.DataAnnotations;

namespace BalancePlatform.Backend.Infrastructure.Entites
{
    /// <summary>
    /// Роль пользователя
    /// </summary>
    public class RoleDao : EntityWithIdDao<int>
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(256)]
        public string Name { get; set; }
        /// <summary>
        /// Активна?
        /// </summary>
        public bool IsActive { get; set; }
    }
}
