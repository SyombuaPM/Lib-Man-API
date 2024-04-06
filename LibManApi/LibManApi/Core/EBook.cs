namespace LibManApi
{
    public class EBook : Book, ILibraryItem
    {
        public string? Isbn_No { get; set; }

        public override string GetDetails()
        {
            return $"{base.GetDetails()}\nISBN Number: {Isbn_No}";
        }

        public bool IsAvailable(int id)
        {
            return !this.IsBorrowed;
        }

        public void Borrow(int id)
        {
            if (IsAvailable(id))
            {
                this.IsBorrowed = true;
                this.Id = id;
            }
            else
            {
                throw new System.Exception("Book is already borrowed");
            }
        }
        public void ReturnBook(int id)
        {
            if (this.Id == id)
            {
                this.IsBorrowed = false;
            }
            else
            {
                throw new System.Exception("Book was not borrowed");
            }

        }

    }
}
