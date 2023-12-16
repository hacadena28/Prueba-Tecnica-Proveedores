using System.Linq.Expressions;

namespace Domain.Ports
{
    public interface IGenericRepository<E> : IDisposable
        where E : DomainEntity
    {
        Task<IEnumerable<E>> GetAll();
        Task<E> GetById(string id);

        Task<IEnumerable<E>> FindAsync(Expression<Func<E, bool>> filter);
        Task Add(E entity);
        Task Update(E entity);
        Task Delete(E entity);
        Task<bool> Exist(string id);
    }
}