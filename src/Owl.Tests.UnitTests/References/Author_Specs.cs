using System.Linq;
using NUnit.Framework;
using Owl.References;

namespace Owl.Tests.UnitTests.References
{
    [TestFixture]
    public class Author_Specs
    {
        private Author SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new Author(null, null);
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        #region Constructor

        [Test]
        public void constructor_should_set_firstName()
        {
            // When
            SUT = new Author("Lastname", "Firstname", "Middle name 1", "Middle name 2");

            // Then
            Assert.AreEqual("Firstname", SUT.FirstName);
        }

        [Test]
        public void constructor_should_set_lastName()
        {
            // When
            SUT = new Author("Lastname", "Firstname", "Middle name 1", "Middle name 2");

            // Then
            Assert.AreEqual("Lastname", SUT.LastName);
        }

        [Test]
        public void constructor_should_set_middleNames_in_order()
        {
            // When
            SUT = new Author("Lastname", "Firstname", "Middle name 1", "Middle name 2");

            // Then
            Assert.AreEqual("Middle name 1", SUT.MiddleNames.ElementAt(0));
            Assert.AreEqual("Middle name 2", SUT.MiddleNames.ElementAt(1));
        }

        #endregion Constructor
    }
}