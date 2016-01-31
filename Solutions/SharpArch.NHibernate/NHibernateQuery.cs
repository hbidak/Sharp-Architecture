namespace SharpArch.NHibernate
{
    using System.Diagnostics.Contracts;
    using global::NHibernate;

    public abstract class NHibernateQuery
    {
        private readonly ISession session;

        protected NHibernateQuery(ISession session)
        {
            Contract.Requires(session != null, "Session is required.");
            this.session = session;
        }

        protected virtual ISession Session
        {
            get
            {
                return this.session;
            }
        }
    }
}