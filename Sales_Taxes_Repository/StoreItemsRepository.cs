using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Taxes_Repository
{
    public class StoreItemsRepository
    {
        protected readonly List<StoreItems> _storeDirectory = new List<StoreItems>();
        protected readonly List<StoreItems> _cartDirectory = new List<StoreItems>();

        public List<StoreItems> ShowAllItems()
        {
            return _storeDirectory;
        }


        public StoreItems GetItemsById(int id)
        {
            foreach (StoreItems singleItem in _storeDirectory)
            {
                if (singleItem.ItemId == id)
                {
                    return singleItem;
                }
            }
            return null;
        }

        public bool AddItemsToStore(StoreItems newContent)
        {
            int startingCount = _storeDirectory.Count;
            _storeDirectory.Add(newContent);
            bool wasAdded = (_storeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddItemsToCart(StoreItems newContent)
        {
            int startingCount = _cartDirectory.Count;
            _cartDirectory.Add(newContent);
            bool wasAdded = (_cartDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<StoreItems> ShowReceipt()
        {
            return _cartDirectory;
        }

        public float SumOfAllTaxes()
        {
            float sum = 0;

            foreach (StoreItems singleItem in _cartDirectory)
            {
                    sum += singleItem.SalesTax;
            }
            return sum;
        }

        public float SumOfAllItems()
        {
            float sum = 0;

            foreach (StoreItems singleItem in _cartDirectory)
            {
                sum += singleItem.SalePrice;
            }
            return sum;
        }
    }
}
