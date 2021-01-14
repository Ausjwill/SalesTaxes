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
        public float SalesTax
        {
            get
            {
                if (ItemType == Type.Imported && ItemCategory == Category.Book)
                {
                    SalesTax = ListPrice * 0.05f;
                }
                else if (ItemType == Type.Imported && ItemCategory == Category.Food)
                {
                    SalesTax = ListPrice * 0.05f;
                }
                else if (ItemType == Type.Imported && ItemCategory == Category.Medical_Product)
                {
                    SalesTax = ListPrice * 0.05f;
                }
                else if (ItemType == Type.Imported && ItemCategory == Category.Other)
                {
                    SalesTax = ListPrice * 0.15f;
                }
                else if (ItemType == Type.Not_Imported && ItemCategory == Category.Book)
                {
                    SalesTax = ListPrice * 0.0f;
                }
                else if (ItemType == Type.Not_Imported && ItemCategory == Category.Food)
                {
                    SalesTax = ListPrice * 0.0f;
                }
                else if (ItemType == Type.Not_Imported && ItemCategory == Category.Medical_Product)
                {
                    SalesTax = ListPrice * 0.0f;
                }
                else if (ItemType == Type.Not_Imported && ItemCategory == Category.Other)
                {
                    SalesTax = ListPrice * 0.1f;
                }
                return SalesTax;
            }
            set { }
        }
        public float SalePrice
        {
            get
            {
                SalePrice = ListPrice + SalesTax;
                return SalePrice;
            }
            set { }
        }

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
