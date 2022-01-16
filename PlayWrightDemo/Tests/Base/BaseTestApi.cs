using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace PlayWrightDemo.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class BaseTestApi
    {
        protected string entitlementsConnectionString;

        [SetUp]
        public void Setup()
        {
            Configuration.Configuration.InitiateConfigurationFile();
            entitlementsConnectionString = Configuration.Configuration.EntitlementsConnectionString;
            Allure.Commons.AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
}
