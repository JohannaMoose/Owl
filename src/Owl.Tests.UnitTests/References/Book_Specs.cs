using System;
using System.Collections.Generic;
using NUnit.Framework;
using Owl.References;

namespace Owl.Tests.UnitTests.References
{
    [TestFixture]
    public class Book_Specs
    {
        private Book SUT;

        [SetUp]
        public void Setup()
        {
            SUT = new Book();
        }

        [TearDown]
        public void Teardown()
        {
            SUT = null;
        }

        #region Constructor

        [Test]
        public void constructor_should_set_id()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreNotEqual(Guid.Empty, SUT.Id);
        }

        [Test]
        public void constructor_should_set_title_to_empty()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual("", SUT.Title);
        }

        [Test]
        public void constructor_should_set_authors_to_empty()
        {
            // When
            SUT = new Book();

            // Then
            Assert.IsEmpty(SUT.Authors);
        }

        [Test]
        public void constructor_should_set_edition_to_neg_1()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual(-1, SUT.Edition);
        }

        [Test]
        public void constructor_should_set_placeOfPublication_to_empty()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual("", SUT.PlaceOfPublication);
        }

        [Test]
        public void constructor_should_set_publisher_to_empty()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual("", SUT.Publisher);
        }


        [Test]
        public void constructor_should_set_yearOfPublication_to_neg_1()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual(-1, SUT.YearOfPublication);
        }


        [Test]
        public void constructor_should_set_startPage_to_neg_1()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual(-1, SUT.StartPage);
        }


        [Test]
        public void constructor_should_set_endPage_to_neg_1()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual(-1, SUT.EndPage);
        }
        
        [Test]
        public void constructor_should_set_ISBN_to_empty()
        {
            // When
            SUT = new Book();

            // Then
            Assert.AreEqual("", SUT.Publisher);
        }


        #endregion Constructor

        #region CreateFull

        [Test]
        public void createFull_should_set_title()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual("My title", SUT.Title);
        }

        [Test]
        public void createFull_should_set_author()
        {
            // Given
            var authors = new List<Author>
            {
                new Author("Name", "A"),
                new Author("Name B", "B")
            };

            // When
            SUT = Book.CreateFull("My title", authors, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual(authors, SUT.Authors);
        }

        [Test]
        public void createFull_should_set_edition()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual(1, SUT.Edition);
        }

        [Test]
        public void createFull_should_set_placeOfPublication()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual("City", SUT.PlaceOfPublication);
        }

        [Test]
        public void createFull_should_set_publisher()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual("Publsiher", SUT.Publisher);
        }

        [Test]
        public void createFull_should_set_yearOfPublication()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual(2010, SUT.YearOfPublication);
        }

        [Test]
        public void createFull_should_set_isbn()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010, "ISBN");

            // Then
            Assert.AreEqual("ISBN", SUT.ISBN);
        }

        [Test]
        public void createFull_should_set_startPage()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010, "ISBN", 1, 3);

            // Then
            Assert.AreEqual(1, SUT.StartPage);
        }

        [Test]
        public void createFull_should_set_endPage()
        {
            // Given

            // When
            SUT = Book.CreateFull("My title", null, 1, "City", "Publsiher", 2010, "ISBN", 1, 3);

            // Then
            Assert.AreEqual(3, SUT.EndPage);
        }

        #endregion CreateFull

        #region Equals

        [Test]
        public void equals_should_return_true_for_same()
        {
            // Given
            var first = Book.CreateFull("My title", new List<Author>
            {
                new Author("Name", "A"),
                new Author("Name B", "B")
            }, 1, "City", "Publsiher", 2010);
            var second = Book.CreateFull("My title", new List<Author>
            {
                new Author("Name", "A"),
                new Author("Name B", "B")
            }, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual(first, second);
        }

        [Test]
        public void equals_should_return_true_even_if_authors_are_ordered_differently()
        {
            // Given 
            var first = Book.CreateFull("My title", new List<Author>
            {
                new Author("Name", "A"),
                new Author("Name B", "B")
            }, 1, "City", "Publsiher", 2010);
            var second = Book.CreateFull("My title", new List<Author>
            {
                new Author("Name B", "B"),
                new Author("Name", "A")
            }, 1, "City", "Publsiher", 2010);

            // Then
            Assert.AreEqual(first, second);
        }

        #endregion Equals
    }
}