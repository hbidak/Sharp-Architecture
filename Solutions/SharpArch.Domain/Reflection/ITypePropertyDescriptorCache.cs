namespace SharpArch.Domain.Reflection
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using DomainModel;

    /// <summary>
    ///     Property descriptors cache.
    /// </summary>
    /// <remarks>Implementation is thread-safe.
    /// todo: update <see cref="BaseObject"/> to use cache.
    /// </remarks>
    [ContractClass(typeof(ITypePropertyDescriptorCacheContract))]
    public interface ITypePropertyDescriptorCache
    {
        /// <summary>
        /// Find cached property descriptor.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><see cref="TypePropertyDescriptor"/> or <c>null</c> if does not exists.</returns>
        TypePropertyDescriptor Find(Type type);

        /// <summary>
        /// Get existing property descriptor or create and cache it.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="factory">The factory to create descriptor.</param>
        /// <returns></returns>
        TypePropertyDescriptor GetOrAdd(Type type, Func<Type, TypePropertyDescriptor> factory);

        /// <summary>
        ///     Clears the cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns number of entries in the cache.
        /// </summary>
        int Count { get; }
    }

    [ContractClassFor(typeof(ITypePropertyDescriptorCache))]
    [SuppressMessage("ReSharper", "InternalMembersMustHaveComments")]
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once InternalMembersMustHaveComments
    abstract class ITypePropertyDescriptorCacheContract : ITypePropertyDescriptorCache
    {
        public TypePropertyDescriptor Find(Type type)
        {
            Contract.Requires(type != null);
            return null;
        }

        public TypePropertyDescriptor GetOrAdd(Type type, Func<Type, TypePropertyDescriptor> factory)
        {
            Contract.Requires(type != null);
            Contract.Requires(factory != null);
            return null;
        }

        public void Clear()
        {
            Contract.Ensures(Count == 0);
        }

        public int Count
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return default(int);
            } 
        }
    }
}