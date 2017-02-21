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
        // Based on http://guides.lib.monash.edu/c.php?g=219786&p=1454249

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
        public void book_should_handle_two_authors()
        {
            // Given
            var reference = "Suhrke, Astri and Howard Adelman. The Path of a Genocide : The Rwanda Crisis From Uganda to Zaire. New Brunswick, N.J.:  Transaction Publishers, 1999.";

            // When
            var result = SUT.Book(reference);

            // Then
            CollectionAssert.Contains(result.Authors, new Author("Suhrke", "Astri"));
            CollectionAssert.Contains(result.Authors, new Author("Adelman", "Howard"));
            Assert.AreEqual("The Path of a Genocide : The Rwanda Crisis From Uganda to Zaire", result.Title);
            Assert.AreEqual("New Brunswick, N.J.", result.PlaceOfPublication);
            Assert.AreEqual("Transaction Publishers", result.Publisher);
            Assert.AreEqual(1999, result.YearOfPublication);
            Assert.AreEqual(1, result.Edition);
        }


        [Test]
        public void book_should_handle_three_authors()
        {
            // Given
            var reference = "Charny, Israel, William Parsons and Samuel Totten. " +
                            "Genocide in the Twentieth Century : Critical Essays and Eyewitness Accounts. New York: Garland Pub, 1995.";

            // When
            var result = SUT.Book(reference);

            // Then
            CollectionAssert.Contains(result.Authors, new Author("Charny", "Israel"));
            CollectionAssert.Contains(result.Authors, new Author("Parsons", "William"));
            CollectionAssert.Contains(result.Authors, new Author("Totten", "Samuel"));
            Assert.AreEqual("Genocide in the Twentieth Century : Critical Essays and Eyewitness Accounts", result.Title);
            Assert.AreEqual("New York", result.PlaceOfPublication);
            Assert.AreEqual("Garland Pub", result.Publisher);
            Assert.AreEqual(1995, result.YearOfPublication);
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