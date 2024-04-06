using System.ComponentModel.DataAnnotations;

namespace LibManApi
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; } 
        public int PublicationYear { get; set; }

        public bool IsBorrowed { get; set; }

        public virtual string GetDetails()
        {
            return $"Title:{Title}\nAuthor:{Author}\nIsBorrowed: {IsBorrowed}\nPublication Year: {PublicationYear}";
        }

    }
}