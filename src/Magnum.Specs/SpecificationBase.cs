// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Specs
{
    using System;
    using MbUnit.Framework;
    using Rhino.Mocks;

    [TestFixture]
    public class SpecificationBase
    {
        #region Setup/Teardown

        [SetUp]
        public void SpecificationSetUp()
        {
            _mocks = new MockRepository();
            Before_each_specification();
        }

        [TearDown]
        public void SpecificationTearDown()
        {
            _mocks = null;
            After_each_specification();
        }

        #endregion

        private MockRepository _mocks;

        protected virtual void Before_each_specification()
        {
        }

        protected virtual void After_each_specification()
        {
        }

        protected TMock Mock<TMock>()
        {
            return _mocks.DynamicMock<TMock>();
        }

        protected TStub Stub<TStub>()
        {
            return _mocks.Stub<TStub>();
        }

        protected IDisposable Record
        {
            get { return _mocks.Record(); }
        }

        protected IDisposable Playback
        {
            get { return _mocks.Playback(); }
        }
    }

    public static class SpecExtensions
    {
        public static void ShouldEqual(this int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        public static void ShouldBeTrue(this bool actual)
        {
            Assert.IsTrue(actual);
        }
        public static void ShouldBeFalse(this bool actual)
        {
            Assert.IsFalse(actual);
        }

        public static void ShouldEqual(this string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldEqual(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
        }

        public static void ShouldBeType<Expected>(this object actual)
        {
            Assert.IsAssignableFrom(typeof(Expected), actual);
        }

        public static void ShouldBeNull(this object actual)
        {
            Assert.IsNull(actual);
        }

        public static void ShouldNotBeNull(this object actual)
        {
            Assert.IsNotNull(actual);
        }
    }
}