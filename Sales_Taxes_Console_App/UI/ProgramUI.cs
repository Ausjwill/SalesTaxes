using Sales_Taxes_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Type = Sales_Taxes_Repository.Type;

namespace Sales_Taxes_Console_App.UI
{
    public class ProgramUI
    {
        private readonly StoreItemsRepository _storeItemsRepo = new StoreItemsRepository();
        private readonly StoreItemsRepository _cartItemsRepo = new StoreItemsRepository();
        public void Run()
        {
            Console.Title = "Sales Taxes";
            //Console.ForegroundColor = ConsoleColor.DarkBlue;
            //Console.ResetColor();
            string title = @"
                          __________________________________________________________
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                           Sales                          |
                         |                           Taxes                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |                                                          |
                         |  -Austin Williams                                        |
                         |__________________________________________________________|
";
            Console.WriteLine(title);
            Thread.Sleep(5000);
            Console.Clear();
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Hello, What would you like to do?");
                Console.WriteLine("1. See all store items\n" +
                "2. Add a new item to store inventory\n" +
                "3. Add an item to your cart\n" +
                "4. View your receipt\n" +
                "5. Exit");
                string adminInput = Console.ReadLine();
                switch (adminInput)
                {
                    case "1":
                        //SHOW ALL
                        ShowAllItems();
                        break;
                    case "2":
                        //ADD NEW
                        AddNewItem();
                        break;
                    case "3":
                        //ADD TO CART
                        AddItemToCart();
                        break;
                    case "4":
                        //VIEW CART
                        ViewReceipt();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        //Default
                        Console.WriteLine("Please enter a valid number between 1 & 5");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowAllItems()
        {
            Console.Clear();
            List<StoreItems> listOfItems = _storeItemsRepo.ShowAllItems();
            foreach (StoreItems content in listOfItems)
            {
                DisplaySimple(content);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void AddNewItem()
        {
            Console.Clear();
            StoreItems content = new StoreItems();
            Console.WriteLine("Enter the item ID:");
            content.ItemId = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Enter the Item Type:");
            Console.WriteLine("1. Imported\n" +
                "2. Not Imported");
            string type = Console.ReadLine();
            switch (type)
            {
                case "1":
                    content.ItemType = Type.Imported;
                    break;
                case "2":
                    content.ItemType = Type.Not_Imported;
                    break;
                default:
                    Console.WriteLine("Please enter 1 or 2");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Enter the Item Category:");
            Console.WriteLine("1. Book\n" +
                "2. Food\n" +
                "3. Medical Product\n" +
                "4. Other");
            string category = Console.ReadLine();
            switch (category)
            {
                case "1":
                    content.ItemCategory = Category.Book;
                    break;
                case "2":
                    content.ItemCategory = Category.Food;
                    break;
                case "3":
                    content.ItemCategory = Category.Medical_Product;
                    break;
                case "4":
                    content.ItemCategory = Category.Other;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 & 4");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            Console.Clear();
            Console.WriteLine("Enter the Item Name:");
            string name = Console.ReadLine();
            content.ItemName = name;

            Console.Clear();
            Console.WriteLine($"Please enter the price:");
            content.ListPrice = float.Parse(Console.ReadLine());

            _storeItemsRepo.AddItemsToStore(content);
        }
        private void AddItemToCart()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of the item you would like to add to your cart:");
            int id = int.Parse(Console.ReadLine());
            StoreItems content = _storeItemsRepo.GetItemsById(id);
            if (content != null)
            {
                _cartItemsRepo.AddItemsToCart(content);
            }
            else
            {
                Console.WriteLine("There are no items that match that ID.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ViewReceipt()
        {
            Console.Clear();
            List<StoreItems> listOfItems = _cartItemsRepo.ShowReceipt();
            foreach (StoreItems content in listOfItems)
            {
                DisplayReceipt(content);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplaySimple(StoreItems content)
        {
            if (content.ItemType == Type.Imported && content.ItemCategory == Category.Book)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemType} {content.ItemCategory} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Food)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemType} {content.ItemName} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Medical_Product)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemType} {content.ItemName} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Other)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemType} {content.ItemName} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Book)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemCategory} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Food)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemName} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Medical_Product)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemName} at ${content.ListPrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Other)
            {
                Console.WriteLine($"{content.ItemId}. {content.ItemName} at ${content.ListPrice}");
            }
        }

        private void DisplayReceipt(StoreItems content)
        {
            if (content.ItemType == Type.Imported && content.ItemCategory == Category.Book)
            {
                float x = content.ListPrice * 0.05;
                content.SalesTax = (float)Math.Round(x * 20, 2) / 20;
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemType} {content.ItemCategory}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Food)
            {
                float x = content.ListPrice * 0.05;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemType} {content.ItemName}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Medical_Product)
            {
                float x = content.ListPrice * 0.05;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemType} {content.ItemName}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Imported && content.ItemCategory == Category.Other)
            {
                float x = content.ListPrice * 0.15;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemType} {content.ItemName}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Book)
            {
                float x = content.ListPrice * 0.00;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemCategory}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Food)
            {
                float x = content.ListPrice * 0.00;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemName}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Medical_Product)
            {
                float x = content.ListPrice * 0.00;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemName}: ${content.SalePrice}");
            }
            else if (content.ItemType == Type.Not_Imported && content.ItemCategory == Category.Other)
            {
                float x = content.ListPrice * 0.10;
                content.SalesTax = (float)(Math.Round(x * 20, 2) / 20);
                content.SalePrice = content.ListPrice + content.SalesTax;
                Console.WriteLine($"{content.ItemName}: ${content.SalePrice}");
            }
        }

        private void SeedContent()
        {
            var storeItemOne = new StoreItems(1, Type.Not_Imported, Category.Book, "", 12.49f);
            var storeItemTwo = new StoreItems(2, Type.Not_Imported, Category.Other, "Music CD", 14.99f);
            var storeItemThree = new StoreItems(3, Type.Not_Imported, Category.Food, "Chocolate bar", 0.85f);
            var storeItemFour = new StoreItems(4, Type.Imported, Category.Food, "box of Chocolates", 10.00f);
            var storeItemFive = new StoreItems(5, Type.Imported, Category.Other, "bottle of perfume", 47.50f);
            var storeItemSix = new StoreItems(6, Type.Imported, Category.Other, "bottle of perfume", 27.99f);
            var storeItemSeven = new StoreItems(7, Type.Not_Imported, Category.Other, "Bottle of perfume", 18.99f);
            var storeItemEight = new StoreItems(8, Type.Not_Imported, Category.Medical_Product, "Packet of headache pills", 9.75f);
            var storeItemNine = new StoreItems(9, Type.Imported, Category.Food, "box of chocolates", 11.25f);

            _storeItemsRepo.AddItemsToStore(storeItemOne);
            _storeItemsRepo.AddItemsToStore(storeItemTwo);
            _storeItemsRepo.AddItemsToStore(storeItemThree);
            _storeItemsRepo.AddItemsToStore(storeItemFour);
            _storeItemsRepo.AddItemsToStore(storeItemFive);
            _storeItemsRepo.AddItemsToStore(storeItemSix);
            _storeItemsRepo.AddItemsToStore(storeItemSeven);
            _storeItemsRepo.AddItemsToStore(storeItemEight);
            _storeItemsRepo.AddItemsToStore(storeItemNine);
        }
    }
}
