using NUnit.Framework;
using CounterApi.Controllers;

namespace UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        //* UnitTest just check if counter variable exist *\\
        readonly int Counter = CounterController.Globals.Counter;
        [Test]
        public void CheckCounter()
        {
            //* Check default value or incremented value *\\
            Assert.That(Counter,Is.GreaterThanOrEqualTo(0));
        }
    }
}
