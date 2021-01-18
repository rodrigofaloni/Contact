using Contacts.Base.Entity;
using System.Linq;

namespace Contacts.Base.Interface
{
    /// <summary>
    /// Class for a base repository.
    /// </summary>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Insert(T entidade);

        T GetById(long id);

        IQueryable<T> List();

        void Update(T entidade);

        void Remove(T entidade);

        /// <summary>
        /// Gets the next identifier.
        /// </summary>
        /// <returns>Return de next identifier.</returns>
        long GetNextId();
    }
}
