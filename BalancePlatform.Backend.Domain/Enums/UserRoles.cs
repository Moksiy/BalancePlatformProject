using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Enums
{
    /// <summary>
    /// Роли пользователей
    /// </summary>
    public enum UserRoles
    {
        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Модератор
        /// </summary>
        Moderator = 2,
        /// <summary>
        /// Пользователь
        /// </summary>
        User = 3
    }
}
