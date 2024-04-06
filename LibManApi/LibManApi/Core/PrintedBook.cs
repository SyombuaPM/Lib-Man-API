namespace LibManApi
{
    public class PrintedBook : Book, ILibraryItem
    {
        public string? FileFormat { get; set; }


        public override string GetDetails()
        {
            return $"{base.GetDetails()}\nFile Format: {FileFormat}";
            
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

        public void ReturnBook( int id)
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

