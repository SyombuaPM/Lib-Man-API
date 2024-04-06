using LibManApi.DAL;

namespace LibManApi
{
    public class LibManService(LibraryDbContext context)
    {

        private LibraryDbContext _libraryDbContext = context;
        public Book AddBook(Book book)
        {
            _libraryDbContext.Books.Add(book);
            _libraryDbContext.SaveChanges();
            return book;

        }

        public EBook AddEBook(EBook eBook)
        {
            _libraryDbContext.EBooks.Add(eBook);
            _libraryDbContext.SaveChanges();
            return eBook;
        }

        public PrintedBook AddPrintedBook(PrintedBook printedBook)
        {
            _libraryDbContext.PrintedBooks.Add(printedBook);
            _libraryDbContext.SaveChanges();
            return printedBook;
        }

        public void DeleteBook(int id)
        {
            var book = _libraryDbContext.Books.Find(id);
            if (book != null)
            {
                _libraryDbContext.Books.Remove(book);
                _libraryDbContext.SaveChanges();
            }
        }

        public string GetBook(int id)
        {
            var book = _libraryDbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book != null)
            {
                return book.GetDetails();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            return _libraryDbContext.Books.ToList();
        }

        public Book UpdateBook(Book book)
        {
            var existingBook = _libraryDbContext.Books.SingleOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                _libraryDbContext.Books.Update(book);
                _libraryDbContext.SaveChanges();
                return book;
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
       

        public void BorrowBook(Book book, int bookId)
        {
            if (book.Id == bookId && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                _libraryDbContext.SaveChanges();
            }
            else
            {
                throw new System.Exception("Book is already borrowed");
            }
        }


        public void ReturnBook(Book book, int bookId)
        {
            if (book.Id == bookId)
            {
                book.IsBorrowed = false;
                _libraryDbContext.SaveChanges();
            }
            else
            {
                throw new System.Exception("Book was not borrowed");
            }
        }
    }

}

