using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kurapov.DAL.Context;
using Kurapov.DAL.Abstractions;

namespace Kurapov.DAL.Implementations
{
    public class GenericUnitOfWork : IDisposable
    {
        // Initialization code
        ApplicationDbContext context;

        public GenericUnitOfWork()
        {
            context = new ApplicationDbContext();
        }


        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }


        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new EFGenericRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        // other methods
    }
}
