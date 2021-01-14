using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Taxes_Repository
{
    public enum Type { Imported, Not_Imported }
    public enum Category { Book, Food, Medical_Product, Other }
    public class StoreItems
    {
        public int ItemId { get; set; }
        public Type ItemType { get; set; }
        public Category ItemCategory { get; set; }
        public string ItemName { get; set; }
        public float ListPrice { get; set; }
        public float SalesTax { get; set; }
        public float SalePrice { get; set; }

        public StoreItems() { }
        public StoreItems(int itemId, Type itemType, Category itemCategory, string itemName, float listPrice)
        {
            ItemId = itemId;
            ItemType = itemType;
            ItemCategory = itemCategory;
            ItemName = itemName;
            ListPrice = listPrice;
        }
    }
}
