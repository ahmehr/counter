using NUnit.Framework;
using CounterApi.Controllers;
using System;

namespace IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        //* Interaction Tests check if All methods working well internally *\\
        readonly CounterController ct = new CounterController();
        [Test]
        public void CheckGet()
        {
            //* First take the static conter value *\\
            //* Second check if conter equals to get method *\\
            var counter = CounterController.Globals.Counter;
            Assert.That(ct.Get(), Is.EqualTo(counter));
        }
        [Test]
        public void CheckPut()
        {
            //* First create a random number between 0 and 1000 *\\
            //* Second take the static conter value *\\
            //* Third check if put method by random is equal to counter + random *\\
            Random r = new Random(); var i = r.Next(0, 1000);
            var counter = CounterController.Globals.Counter;
            Assert.That(ct.Put(i), Is.EqualTo((counter + i).ToString()));
        }
        [Test]
        public void CheckPost()
        {
            //* Chceck if post method reset the counter to 0 *\\
            ct.Reset();
            Assert.That(ct.Get(), Is.EqualTo(0));
        }
    }
}
