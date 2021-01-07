using System.Threading.Tasks;

namespace Kurapov.DAL.Abstractions
{
    interface IGenericUnitOfWork
    {
        void SaveChanges();
        Task SaveAsync();
        IGenericRepository<T> IGenericRepository<T>() where T : class;
    }
}
