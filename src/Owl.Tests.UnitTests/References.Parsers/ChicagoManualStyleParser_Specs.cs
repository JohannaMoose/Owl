using System.Linq;
using NUnit.Framework;
using Owl.References;
using Owl.References.Parsers;

namespace Owl.Tests.UnitTests.References.Parsers
{
    [TestFixture]
    public class ChicagoManualStyleParser_Specs
    {
        private ChicagoManualStyleParser SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new ChicagoManualStyleParser();
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        [Test]
        public void should_be_ReferenceParser()
        {
            Assert.IsInstanceOf<ReferenceParser>(SUT);
        }

        #region Book

        [Test]
        public void book_should_handle_one_author()
        {
            // Given
            var reference = "Faulkner, William. Absalom, Absalom!. New York: Vintage Books, 1990.";

            // When
            var result = SUT.Book(reference);

            // Then
            Assert.AreEqual(new Author("Faulkner", "William"), result.Authors.ElementAt(0));
            Assert.AreEqual("Absalom, Absalom!", result.Title);
            Assert.AreEqual("New York", result.PlaceOfPublication);
            Assert.AreEqual("Vintage Books", result.Publisher);
            Assert.AreEqual(1990, result.YearOfPublication);
            Assert.AreEqual(1, result.Edition);
        }

        [Test]
        public void book_should_handle_edition_of_book()
        {
            // Given
            var reference = "Faulkner, William. Absalom, Absalom!. 2nd ed. New York: Vintage Books, 1990.";

            // When
            var result = SUT.Book(reference);

            // Then
            Assert.AreEqual(new Author("Faulkner", "William"), result.Authors.ElementAt(0));
            Assert.AreEqual("Absalom, Absalom!", result.Title);
            Assert.AreEqual("New York", result.PlaceOfPublication);
            Assert.AreEqual("Vintage Books", result.Publisher);
            Assert.AreEqual(1990, result.YearOfPublication);
            Assert.AreEqual(2, result.Edition);
        }

        #endregion Book
    }
}