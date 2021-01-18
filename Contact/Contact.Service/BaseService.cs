﻿using Contacts.Base.Entity;
using Contacts.Base.Interface;
using System;
using System.Linq;

namespace Contacts.Base.Service
{
    /// <summary>
    /// Class implements the base service.
    /// </summary>
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets the base repository.
        /// </summary>
        /// <value>
        /// The base repository.
        /// </value>
        protected IBaseRepository<T> BaseRepository { get; set; }

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed = false;

        #endregion

        #region Constructor and destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{T}"/> class.
        /// </summary>
        /// <param name="baseRepository">The base repository.</param>
        public BaseService(IBaseRepository<T> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="BaseService{T}"/> class.
        /// </summary>
        ~BaseService()
        {
            this.Dispose(false);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Return the entity.</returns>
        public T GetById(string id) => BaseRepository.GetById(id);

        /// <summary>
        /// Insert the specified entidade.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity) => InternalInsert(entity);

        /// <summary>
        /// Removers the specified entidade.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            this.InternalRemove(entity);
        }

        /// <summary>
        /// Update the specified entity.
        /// </summary>
        /// <param name="entidade">The entity.</param>
        public void Update(T entity) => InternalUpdate(entity);

        /// <summary>
        /// Gets the next identifier.
        /// </summary>
        /// <returns>Return de next identifier.</returns>
        public string GetNextId()
        {
            return this.BaseRepository.GetNextId();
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>
        /// Return the instance.
        /// </returns>
        public IQueryable<T> List() => BaseRepository.List();

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Internals the insert.
        /// </summary>
        /// <param name="entidade">The entity.</param>
        protected virtual void InternalInsert(T entity)
        {
            this.BaseRepository.Insert(entity);
        }

        /// <summary>
        /// Internals the update.
        /// </summary>
        /// <param name="entidade">The entity.</param>
        protected virtual void InternalUpdate(T entity)
        {
            this.BaseRepository.Update(entity);
        }

        /// <summary>
        /// Internals the remove.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void InternalRemove(T entity)
        {
            this.BaseRepository.Remove(entity);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this.disposed = true;
            }
        }

        #endregion
    }
}
