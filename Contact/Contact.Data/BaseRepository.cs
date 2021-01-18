using Contacts.Base.Entity;
using Contacts.Base.Interface;
using Contacts.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contacts.Base.Repository
{
    /// <summary>
    /// Class implements the base repository.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The context.
        /// </summary>
        protected readonly BaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BaseRepository(BaseContext context)
            : base()
        {
            this._context = context;
        }


        /// <summary>
        /// Inserts the specified entidade.
        /// </summary>
        /// <param name="entidade">The entity.</param>
        /// <returns>Return the entity.</returns>
        public T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>Return the instance.</returns>
        public IQueryable<T> List()
        {
            var lista = _context.Set<T>().AsNoTracking();
            return lista;
        }

        /// <summary>
        /// Updates the specified entidade.
        /// </summary>
        /// <param name="entidade">The entity.</param>
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the entity.</returns>
        public T GetById(long id)
        {
            var entidade = _context.Set<T>().Find(id);
            return entidade;
        }

        /// <summary>
        /// Gets the next identifier.
        /// </summary>
        /// <returns>Return de next identifier.</returns>
        public long GetNextId()
        {
            if(_context.Set<T>().Count() > 0)
            {
                return _context.Set<T>().Max(x => x.Id) + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
