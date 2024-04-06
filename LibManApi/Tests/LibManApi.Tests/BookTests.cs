
namespace LibManApi.Tests;

[TestClass]
public class BookTests
{
    [TestMethod]
    public void TestEBookGetDetails()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = false,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        string details = eBook.GetDetails();

        // Assert
        Assert.AreEqual("Title:The Great Gatsby\nAuthor:F. Scott Fitzgerald\nIsBorrowed: False\nPublication Year: 1925\nISBN Number: 978-3-16-148410-0", details);
    }

    [TestMethod]
    public void TestPrintedBookGetDetails()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = false,
            FileFormat = "Paperback"
        };

        // Act
        string details = printedBook.GetDetails();

        // Assert
        Assert.AreEqual("Title:The Catcher in the Rye\nAuthor:J.D. Salinger\nIsBorrowed: False\nPublication Year: 1951\nFile Format: Paperback", details);
    }

    [TestMethod]
    public void TestEBookIsAvailable()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = false,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        bool available = eBook.IsAvailable(1);

        // Assert
        Assert.IsTrue(available);
    }

    [TestMethod]
    public void TestPrintedBookIsAvailable()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = false,
            FileFormat = "Paperback"
        };

        // Act
        bool available = printedBook.IsAvailable(2);

        // Assert
        Assert.IsTrue(available);
    }

    [TestMethod]
    public void TestEBookBorrow()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = false,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        eBook.Borrow(1);

        // Assert
        Assert.IsTrue(eBook.IsBorrowed);
    }

    [TestMethod]
    public void TestPrintedBookBorrow()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = false,
            FileFormat = "Paperback"
        };

        // Act
        printedBook.Borrow(2);

        // Assert
        Assert.IsTrue(printedBook.IsBorrowed);
    }

    [TestMethod]
    public void TestEBookReturnBook()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = true,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        eBook.ReturnBook(1);

        // Assert
        Assert.IsFalse(eBook.IsBorrowed);
    }

    [TestMethod]
    public void TestPrintedBookReturnBook()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = true,
            FileFormat = "Paperback"
        };

        // Act
        printedBook.ReturnBook(2);

        // Assert
        Assert.IsFalse(printedBook.IsBorrowed);
    }

    [TestMethod]
    public void TestEBookReturnBookNotBorrowed()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = false,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act and Assert
        Assert.ThrowsException<System.Exception>(() => eBook.ReturnBook(1));
    }

    [TestMethod]
    public void TestPrintedBookReturnBookNotBorrowed()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = false,
            FileFormat = "Paperback"
        };

        // Act and Assert
        Assert.ThrowsException<System.Exception>(() => printedBook.ReturnBook(2));
    }

    [TestMethod]
    public void TestEBookBorrowAlreadyBorrowed()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = true,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act and Assert
        Assert.ThrowsException<System.Exception>(() => eBook.Borrow(1));
    }

    [TestMethod]
    public void TestPrintedBookBorrowAlreadyBorrowed()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = true,
            FileFormat = "Paperback"
        };

        // Act and Assert
        Assert.ThrowsException<System.Exception>(() => printedBook.Borrow(2));
    }

    [TestMethod]
    public void TestEBookIsAvailableFalse()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = true,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        bool available = eBook.IsAvailable(1);

        // Assert
        Assert.IsFalse(available);
    }

    [TestMethod]
    public void TestPrintedBookIsAvailableFalse()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = true,
            FileFormat = "Paperback"
        };

        // Act
        bool available = printedBook.IsAvailable(2);

        // Assert
        Assert.IsFalse(available);
    }

    [TestMethod]
    public void TestEBookGetDetailsWithIsBorrowedTrue()
    {
        // Arrange
        EBook eBook = new EBook
        {
            Id = 1,
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            PublicationYear = 1925,
            IsBorrowed = true,
            Isbn_No = "978-3-16-148410-0"
        };

        // Act
        string details = eBook.GetDetails();

        // Assert
        Assert.AreEqual("Title:The Great Gatsby\nAuthor:F. Scott Fitzgerald\nIsBorrowed: True\nPublication Year: 1925\nISBN Number: 978-3-16-148410-0", details);
    }

    [TestMethod]
    public void TestPrintedBookGetDetailsWithIsBorrowedTrue()
    {
        // Arrange
        PrintedBook printedBook = new PrintedBook
        {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            PublicationYear = 1951,
            IsBorrowed = true,
            FileFormat = "Paperback"
        };

        // Act
        string details = printedBook.GetDetails();

        // Assert
        Assert.AreEqual("Title:The Catcher in the Rye\nAuthor:J.D. Salinger\nIsBorrowed: True\nPublication Year: 1951\nFile Format: Paperback", details);
    }

}
