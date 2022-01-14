using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    public class BaseTestApi
    {
        protected string entitlementsConnectionString;

        [SetUp]
        public void Setup()
        {
            Configuration.Configuration.InitiateConfigurationFile();
            entitlementsConnectionString = Configuration.Configuration.EntitlementsConnectionString;
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
}
