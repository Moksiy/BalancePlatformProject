using BalancePlatform.Backend.Domain.Services.Interfaces.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancePlatform.Backend.Domain.Services.Implementations.BaseImplementations
{
    /// <summary>
    /// Абстрактный базовый UnitOfWork-сервис
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
