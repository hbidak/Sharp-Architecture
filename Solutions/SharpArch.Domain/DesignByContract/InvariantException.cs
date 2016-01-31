#if LEGACY_DESIGN_BY_CONTRACT
namespace SharpArch.Domain
{
    using System;

    /// <summary>
    ///     An exception that is raised when an invariant check fails.
    /// </summary>
    [Obsolete("Will be removed in next version. Please use Microsoft Code Contracts.")]
    public class InvariantException : DesignByContractException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        public InvariantException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvariantException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner exception.</param>
        public InvariantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
#endif