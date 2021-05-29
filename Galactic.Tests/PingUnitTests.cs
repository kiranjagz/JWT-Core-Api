using Galactic.Services.Pong;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Galactic.Tests
{
    [TestFixture]
    public class PingUnitTests
    {
        private PingService _pingService;
        [SetUp]
        public void Setup()
        {
            _pingService = new PingService();
        }

        [Test]
        public async Task Test_Returns_PingAsync()
        {
            var result = await _pingService.Ping();

            Assert.That(result, Is.EqualTo("Pong!"));
        }
    }
}
