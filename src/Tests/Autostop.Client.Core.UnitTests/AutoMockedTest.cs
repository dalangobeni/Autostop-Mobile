﻿using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;

namespace Autostop.Client.Core.UnitTests
{
    public abstract class BaseAutoMockedTest<T>
        where T : class
    {
        protected virtual T ClassUnderTest => Mocker.Create<T>();

        protected AutoMock Mocker { get; private set; }

        [SetUp]
        public virtual void Init()
        {
            Mocker = AutoMock.GetLoose();
        }

        [TearDown]
        public void TearDown()
        {
            Mocker?.Dispose();
        }

        protected Mock<TDepend> GetMock<TDepend>()
            where TDepend : class
        {
            return Mocker.Mock<TDepend>();
        }
    }
}