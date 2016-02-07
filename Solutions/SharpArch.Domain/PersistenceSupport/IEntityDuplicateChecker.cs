namespace SharpArch.Domain.PersistenceSupport
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using DomainModel;

    /// <summary>
    ///     Defines the public members of a class that checks an entity for duplicates.
    /// </summary>
    [ContractClass(typeof(IEnitityDuplicateCheckerContract))]
    public interface IEntityDuplicateChecker
    {
        /// <summary>
        ///     Returns a value indicating whether a duplicate of the specified entity exists.
        /// </summary>
        /// <typeparam name="TId">The type of the ID that identifies the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if a duplicate exists, <c>false</c> otherwise.</returns>
        bool DoesDuplicateExistWithTypedIdOf<TId>(IEntityWithTypedId<TId> entity);
    }


    [ContractClassFor(typeof(IEntityDuplicateChecker))]
    [SuppressMessage("ReSharper", "InternalMembersMustHaveComments")]
    // ReSharper disable once InternalMembersMustHaveComments
    // ReSharper disable once InconsistentNaming
    abstract class IEnitityDuplicateCheckerContract: IEntityDuplicateChecker
    {
        public bool DoesDuplicateExistWithTypedIdOf<TId>(IEntityWithTypedId<TId> entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "Entity may not be null when checking for duplicates.");
            return false;

        }
    }

}
