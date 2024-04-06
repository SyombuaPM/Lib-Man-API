namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public partial class Product
    {

        public static int StockThreshold = 5;

        public static void ChangeStockTreshold(int newStockTreshhold)
        {
            //we will only allow this to go through if the value is > 0
            if (newStockTreshhold > 0)
                StockThreshold = newStockTreshhold;
        }


        public void Log(string message)
        {
            //this could be written to a file
            Console.WriteLine(message);
        }

        public string CreateSimpleProductRepresentation()
        {
            return $"Product {Id} ({Name})";
        }
    }
}
