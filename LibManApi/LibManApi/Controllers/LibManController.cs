using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http.HttpResults;
using LibManApi.DAL;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibManApi
{
    [ApiController]
    [Route("/api/(Books)")]

    public class LibManController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly LibManService _libManService;

        public LibManController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
            _libManService = new LibManService(libraryDbContext);
        }

        [HttpGet("/books")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _libManService.GetBooks();
            if (books.Count() == 0)
            {
                return new NotFoundObjectResult(new { Error = "No books found" });
            }

            return new ActionResult<IEnumerable<Book>>(books);
        }

        [HttpGet("/api/books")]
        public ActionResult GetBooks2()
        {
            List<Book> books = _libManService.GetBooks().ToList();
            if (books.Count() == 0)
            {
                return new NotFoundObjectResult(new { Error = "No books found" });
            }
            books.Add(new PrintedBook { Id = 1, Title = "The Alchemist", FileFormat = "PDF", Author = "Paulo Coelho", PublicationYear = 1988, IsBorrowed = false });

            return Ok(books);
        }




        // [HttpGet] // Retrieving a list of all books depending with the type of book---ask for help
        // public ActionResult<IEnumerable<string>> GetBooks()
        // {
        //     var books = _libraryDbContext.Books.ToList();
        //     if (books.Count == 0)
        //     {
        //         return new NotFoundObjectResult(new { Error = "No books found" });
        //     }

        //     var bookDetails = books.Select(b => b.GetDetails()).ToList();
        //     return bookDetails;
        // }

        // [HttpGet("{id}")]
        // public ActionResult<Book> GetBook(int id)
        // {
        //     var book = _libraryDbContext.Books.SingleOrDefault(b => b.Id == id);
        //     if (book == null)
        //     {
        //         return new NotFoundObjectResult(new { Error = "No book with that ID found" });
        //     }

        //     return book;
        // }
        [HttpGet("/Api/Books/{id}")]
        public ActionResult<string> GetBook(int id)
        {
            var book = _libraryDbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return new NotFoundObjectResult(new { Error = "No book with that ID found" });
            }

            return book.GetDetails();
        }

        [HttpPost("/Api/Books/EBook")]

        public ActionResult<EBook> AddEBook([FromBody] EBook eBook)
        {
            var newEBook = _libManService.AddEBook(eBook);
            return newEBook;
        }

        [HttpPost("Printed Book")]

        public ActionResult<PrintedBook> AddPrintedBook([FromBody] PrintedBook printedBook)
        {
            var newPrintedBook = _libManService.AddPrintedBook(printedBook);
            return newPrintedBook;
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book book)
        {
            var updatedBook = _libManService.UpdateBook(book);
            return updatedBook;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _libManService.DeleteBook(id);
            return new OkResult();
        }


    }
}
