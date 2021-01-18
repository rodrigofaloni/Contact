using Contacts.Base.Entity;
using System.Linq;

namespace Contacts.Base.Interface
{
    /// <summary>
    /// Class for a base service.
    /// </summary>
    public interface IBaseService<T> where T : BaseEntity
    {
        IQueryable<T> List();

        T GetById(string id);

        void Insert(T entidade);

        void Remove(T entidade);

        void Update(T entidade);

        /// <summary>
        /// Gets the next identifier.
        /// </summary>
        /// <returns>Return de next identifier.</returns>
        string GetNextId();
    }
}
