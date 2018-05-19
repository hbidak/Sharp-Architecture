﻿// ReSharper disable MissingAnnotation
// ReSharper disable ExceptionNotDocumented
namespace Tests.SharpArch.NHibernate
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using global::NHibernate;
    using global::SharpArch.Domain.PersistenceSupport;
    using global::SharpArch.NHibernate;
    using global::SharpArch.Testing.NUnit.NHibernate;
    using Moq;
    using NUnit.Framework;

    internal class HasUniqueDomainSignatureTestsBase: RepositoryTestsBase
    {
        protected Mock<IServiceProvider> ServiceProviderMock;
        protected ValidationContext ValidationContext;

        protected override void LoadTestData()
        {
            
        }

        [SetUp]
        protected override void SetUp()
        {
            base.SetUp();

            ServiceProviderMock = new Mock<IServiceProvider>();
            ServiceProviderMock.Setup(sp => sp.GetService(typeof(IEntityDuplicateChecker)))
                .Returns(new EntityDuplicateChecker(Session));
        }


        protected ValidationContext ValidationContextFor(object objectToValidate)
        {
            return new ValidationContext(objectToValidate, ServiceProviderMock.Object, null);
        }

    }
}
