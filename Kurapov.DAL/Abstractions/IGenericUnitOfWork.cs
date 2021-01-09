using System.Threading.Tasks;

namespace Kurapov.DAL.Abstractions
{
    public interface IGenericUnitOfWork
    {
        void SaveChanges();
        Task SaveAsync();
        IGenericRepository<T> IGenericRepository<T>() where T : class;
    }
}
