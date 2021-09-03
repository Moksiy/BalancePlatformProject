using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Infrastructure.Contexts
{
    /// <summary>
    /// Базовый EF DbContext
    /// </summary>
    public abstract class BaseDbContext : DbContext
    {
        /// <summary>
        /// Базовый EF DbContext
        /// </summary>
        protected BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
