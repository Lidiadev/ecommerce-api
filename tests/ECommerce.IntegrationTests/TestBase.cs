using NUnit.Framework;
using System.Net.Http;

namespace ECommerce.IntegrationTests
{
    public abstract class TestBase
    {
        private TestWebApplicationFactory _testWebFactory;
        protected HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _testWebFactory = new TestWebApplicationFactory();
            _client = _testWebFactory.CreateClient();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _client.Dispose();
            _testWebFactory.Dispose();
        }
    }
}
