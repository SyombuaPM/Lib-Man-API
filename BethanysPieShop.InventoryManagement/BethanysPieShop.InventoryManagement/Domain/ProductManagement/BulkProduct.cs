using BethanysPieShop.InventoryManagement.Domain.Contracts;
using BethanysPieShop.InventoryManagement.Domain.General;

namespace BethanysPieShop.InventoryManagement.Domain.ProductManagement
{
    public class BulkProduct : Product, ISaveable
    {
        public BulkProduct(int id, string name, string? description, Price price, int maxAmountInStock) : base(id, name, description, price, UnitType.PerKg, maxAmountInStock)
        {
        }

        public string ConvertToStringForSaving()
        {
            return $"{Id};{Name};{Description};{maxItemsInStock};{Price.ItemPrice};{(int)Price.Currency};{(int)UnitType};3;";
        }

        public override void IncreaseStock()
        {
            AmountInStock++;
        }

        public override Product Clone()
        {
            return new BulkProduct(Id, Name, Description, Price, maxItemsInStock);
        }
    }
}
