namespace SharpArch.NHibernate.FluentNHibernate.Conventions
{
    using global::FluentNHibernate.Conventions;
    using global::FluentNHibernate.Conventions.Instances;

    /// <summary>
    ///     Table name convention.
    /// </summary>
    /// <remarks>Defines table name to match entity name. E.g.: <c>Color</c>.</remarks>
    /// <seealso cref="IClassConvention" />
    public class TableNameConvention : IClassConvention
    {
        /// <summary>
        ///     Applies convention.
        /// </summary>
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name);
        }
    }
}