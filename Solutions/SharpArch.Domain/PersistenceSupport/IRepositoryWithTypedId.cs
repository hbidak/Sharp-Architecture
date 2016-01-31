namespace SharpArch.Domain.PersistenceSupport
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    /// <summary>
    ///     Defines the public members of a class that implements the repository pattern for entities
    ///     of the specified type.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TId">The type of the entity ID.</typeparam>
    [ContractClass(typeof(IRepositoryWithTypedIdContract<,>))]
    public interface IRepositoryWithTypedId<T, in TId>
    {
        /// <summary>
        ///     Returns the database context, which provides a handle to application wide DB
        ///     activities such as committing any pending changes, beginning a transaction,
        ///     rolling back a transaction, etc.
        /// </summary>
        ITransactionManager TransactionManager { get; }

        /// <summary>
        ///     Returns the entity that matches the specified ID.
        /// </summary>
        /// <remarks>
        ///     An entity or <c>null</c> if a row is not found matching the provided ID.
        /// </remarks>
        T Get(TId id);

        /// <summary>
        ///     Returns all of the items of a given type.
        /// </summary>
        IList<T> GetAll();

        /// <summary>
        /// For entities that have assigned Id's, you must explicitly call Save to add a new one.
        /// See http://www.hibernate.org/hib_docs/nhibernate/html_single/#mapping-declaration-id-assigned.
        /// </summary>
        T Save(T entity);

        /// <summary>
        ///     Saves or updates the specified entity.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         For entities with automatically generated IDs, such as identity,
        ///         <see cref="SaveOrUpdate"/>  may be called when saving or updating an entity.
        ///     </para>
        ///     <para>
        ///         Updating also allows you to commit changes to a detached object.
        ///         More info may be found at:
        ///         http://www.hibernate.org/hib_docs/nhibernate/html_single/#manipulatingdata-updating-detached
        ///     </para>
        /// </remarks>
        T SaveOrUpdate(T entity);


        /// <summary>
        /// Disassociates the entity with the ORM so that changes made to it are not automatically 
        /// saved to the database.
        /// </summary>
        /// <remarks>
        /// In NHibernate this removes the entity from current session cache.
        /// More details may be found at http://www.hibernate.org/hib_docs/nhibernate/html_single/#performance-sessioncache.
        /// </remarks>
        void Evict(T entity);


        /// <summary>
        ///     Deletes the specified entity.
        /// </summary>
        void Delete(T entity);

        /// <summary>
        ///     Deletes the entity that matches the provided ID.
        /// </summary>
        void Delete(TId id);
    }


    #region Code contract definition

    // ReSharper disable once InternalMembersMustHaveComments
    // ReSharper disable once InconsistentNaming
    [SuppressMessage("ReSharper", "InternalMembersMustHaveComments")]
    [ContractClassFor(typeof(IRepositoryWithTypedId<,>))]
    abstract class IRepositoryWithTypedIdContract<T, TId> : IRepositoryWithTypedId<T, TId>
    {
        public ITransactionManager TransactionManager
        {
            get
            {
                Contract.Ensures(Contract.Result<ITransactionManager>() != null);
                return default(ITransactionManager);
            }
        }

        public T Get(TId id)
        {
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        public IList<T> GetAll()
        {
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            return null;
        }

        public T Save(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, nameof(entity));
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        public T SaveOrUpdate(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, nameof(entity));
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        public void Evict(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, nameof(entity));
        }

        public void Delete(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, nameof(entity));
        }

        /// <summary>
        ///     Deletes the entity that matches the provided ID.
        /// </summary>
        public void Delete(TId id)
        {
        }
    }

    #endregion
}