namespace SharpArch.NHibernate.Contracts.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using global::NHibernate;

    using SharpArch.Domain;
    using SharpArch.Domain.PersistenceSupport;

    /// <summary>
    /// Defines NHibernate-specific extensions for <see cref="IRepositoryWithTypedId{T,TId}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    /// <seealso cref="SharpArch.Domain.PersistenceSupport.IRepositoryWithTypedId{T, TId}" />
    public interface INHibernateRepositoryWithTypedId<T, in TId> : IRepositoryWithTypedId<T, TId>
    {
        /// <summary>
        /// Looks for zero or more instances using the properties provided.
        /// The key of the collection should be the property name and the value should be
        /// the value of the property to filter by.
        /// </summary>
        IList<T> FindAll(IDictionary<string, object> propertyValuePairs);

        /// <summary>
        /// Looks for zero or more instances using the example provided.
        /// </summary>
        IList<T> FindAll(T exampleInstance, params string[] propertiesToExclude);

        /// <summary>
        /// Looks for a single instance using the property/values provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        T FindOne(IDictionary<string, object> propertyValuePairs);

        /// <summary>
        /// Looks for a single instance using the example provided.
        /// </summary>
        /// <exception cref="NonUniqueResultException" />
        T FindOne(T exampleInstance, params string[] propertiesToExclude);

        /// <summary>
        /// Returns null if a row is not found matching the provided Id.
        /// </summary>
        T Get(TId id, Enums.LockMode lockMode);

        /// <summary>
        /// Throws an exception if a row is not found matching the provided Id.
        /// </summary>
        T Load(TId id);

        /// <summary>
        /// Throws an exception if a row is not found matching the provided Id.
        /// </summary>
        T Load(TId id, Enums.LockMode lockMode);

        /// <summary>
        /// For entities that have assigned Id's, you should explicitly call Update to update an existing one.
        /// Updating also allows you to commit changes to a detached object.  More info may be found at:
        /// http://www.hibernate.org/hib_docs/nhibernate/html_single/#manipulatingdata-updating-detached
        /// </summary>
        T Update(T entity);

    }

    #region Contract

    // ReSharper disable once InconsistentNaming
    // ReSharper disable once InternalMembersMustHaveComments
    [SuppressMessage("ReSharper", "InternalMembersMustHaveComments")]
    abstract class INHibernateRepositoryWithTypedIdContract<T, TId> : INHibernateRepositoryWithTypedId<T, TId>
    {
        public IList<T> FindAll(IDictionary<string, object> propertyValuePairs)
        {
            Contract.Requires<ArgumentNullException>(propertyValuePairs != null, nameof(propertyValuePairs));
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            return null;
        }

        public IList<T> FindAll(T exampleInstance, params string[] propertiesToExclude)
        {
            Contract.Requires<ArgumentNullException>(exampleInstance != null, nameof(exampleInstance));
            Contract.Ensures(Contract.Result<IList<T>>() != null);
            return null;
        }

        public T FindOne(IDictionary<string, object> propertyValuePairs)
        {
            Contract.Requires<ArgumentNullException>(propertyValuePairs != null, nameof(propertyValuePairs));
            Contract.ForAll(propertyValuePairs, kvp => string.IsNullOrWhiteSpace(kvp.Key) == false);

            return default(T);
        }

        public T FindOne(T exampleInstance, params string[] propertiesToExclude)
        {
            Contract.Requires<ArgumentNullException>(exampleInstance != null, nameof(exampleInstance));
            return default(T);
        }

        public T Get(TId id, Enums.LockMode lockMode)
        {
            return default(T);
        }

        public T Load(TId id)
        {
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        public T Load(TId id, Enums.LockMode lockMode)
        {
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        public T Update(T entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, nameof(entity));
            return default(T);
        }

        #region Base class contracts

        public abstract ITransactionManager TransactionManager { get; }

        public abstract T Get(TId id);

        public abstract IList<T> GetAll();

        public abstract T Save(T entity);

        public abstract T SaveOrUpdate(T entity);

        public abstract void Evict(T entity);

        public abstract void Delete(T entity);

        public abstract void Delete(TId id);

        #endregion
    }

    #endregion
}