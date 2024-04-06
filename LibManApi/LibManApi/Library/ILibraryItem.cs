namespace LibManApi
{
    public interface ILibraryItem
    {
        public string GetDetails();
        public bool IsAvailable(int id);
        public void Borrow( int id);
        public void ReturnBook(int id);
       
    }
}

