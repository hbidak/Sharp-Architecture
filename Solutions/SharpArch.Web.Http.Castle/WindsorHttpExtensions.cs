namespace SharpArch.Web.Http.Castle
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Reflection;
    using global::Castle.Core;
    using global::Castle.MicroKernel.Registration;
    using global::Castle.Windsor;

    /// <summary>
    /// Contains Castle Windsor related HTTP controller extension methods.
    /// </summary>
    public static class WindsorHttpExtensions
    {
        /// <summary>
        /// Registers the specified WebAPI controllers.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="controllerTypes">The controller types.</param>
        /// <returns>A container.</returns>
        public static IWindsorContainer RegisterHttpControllers(this IWindsorContainer container, params Type[] controllerTypes)
        {
            Contract.Requires(container != null);
            Contract.Requires(controllerTypes != null);

            foreach (Type type in controllerTypes.Where(type => type.IsHttpController()))
            {
                container.Register(
                    Component.For(type).Named(type.FullName).LifeStyle.Is(LifestyleType.Scoped));
            }

            return container;
        }

        /// <summary>
        /// Registers the WebAPI controllers from specified assemblies.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>A container.</returns>
        public static IWindsorContainer RegisterHttpControllers(this IWindsorContainer container, params Assembly[] assemblies)
        {
            Contract.Requires(container != null);
            Contract.Requires(assemblies != null);

            foreach (Assembly assembly in assemblies)
            {
                RegisterHttpControllers(container, assembly.GetExportedTypes());
            }

            return container;
        }

    }
}
