using Prueba.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prueba.DataAccess.Class
{
    public class UnitOfWork : IDisposable
    {
        private readonly PruebaContext dbContext;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public UnitOfWork(PruebaContext PruebaContext)
        {
            dbContext = PruebaContext;
        }

        public UnitOfWork()
        {
            dbContext = new PruebaContext();
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Get Current Context
        /// </summary>
        /// <returns></returns>
        public PruebaContext GetContext()
        {
            return this.dbContext;
        }

        /// <summary>
        /// Create a new Repository
        /// </summary>
        /// <typeparam name="T">Class Entity</typeparam>
        /// <returns>New Repository Entity</returns>
        public Repository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), dbContext);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        /// <summary>
        /// Disposing 
        /// </summary>
        /// <param name="disposing">Bool to dispose</param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
