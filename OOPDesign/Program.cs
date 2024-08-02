using OOPDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          // Application.Run(new Form1());
            Application.Run(new MainWindow());
          //Application.Run(new CompanyWindow());

            Random random = new Random();

            Inventory inventory = new Inventory();
            StoreOwner owner = new StoreOwner("John", "Doe", "123 Main St", "111-111-1111");
            FurnitureItem furnitureItem1 = new FurnitureItem(1, "Sofa", "Reclining one", 800m, 6m, 3m, 2m, 40);
            FurnitureItem furnitureItem2 = new FurnitureItem(2, "Chair", "Non Reclining beige color", 50m, 1m, 1m, 1m, 10);
            FurnitureItem furnitureItem3 = new FurnitureItem(3, "Dinning Table", "Nice and Strong", 3000m, 8m, 2m, 1m, 200);
            FurnitureItem furnitureItem4 = new FurnitureItem(4, "Bed", "Cool and Comfy", 1100m, 8m, 2m, 1m, 100);
            FurnitureItem furnitureItem5 = new FurnitureItem(34, "Very Costly Item", "Just for Demo", 9900, 1, 1, 1, 1);
            FurnitureItem furnitureItem500Plus = new FurnitureItem(345, "500+", "500 Plus", 501, 1, 1, 1, 1);

            owner.AddsAnItem(furnitureItem1, inventory);
            owner.AddsAnItem(furnitureItem2, inventory);
            owner.AddsAnItem(furnitureItem3, inventory);
            owner.AddsAnItem(furnitureItem4, inventory);
            owner.AddsAnItem(furnitureItem5, inventory);
            owner.AddsAnItem(furnitureItem500Plus, inventory);

            GroceryItem groceryItem1 = new GroceryItem(5, "Bulk apples", "Too many apples", 20m, GroceryCategory.Fruit, DateTime.Today, DateTime.Today.AddDays(14));
            GroceryItem groceryItem2 = new GroceryItem(6, "30 lb Meat", "Too much meat", 200m, GroceryCategory.Fruit, DateTime.Today, DateTime.Today.AddDays(10));
            GroceryItem groceryItem3 = new GroceryItem(7, "Milk", "Too much milk", 5m, GroceryCategory.Dairy, DateTime.Today, DateTime.Today.AddDays(7));

            BookItem book1 = new BookItem(7, "A Good Programming Book", "A very good book", 500m, "1-1-11-1111", "Karen S", BookGenre.NonFiction);
            BookItem book2 = new BookItem(8, "An Excellent English Grammer Book", "A very good but costly grammar book", 1000m, "2-2-22-2222", "Dave D", BookGenre.NonFiction);
            BookItem book5 = new BookItem(9, "A Bad Programming Book", "A very bad book", 50m, "3-3-33-3333", "John Doe", BookGenre.NonFiction);

            owner.AddsAnItem(groceryItem1, inventory);
            owner.AddsAnItem(groceryItem2, inventory);
            owner.AddsAnItem(groceryItem3, inventory);

            owner.AddsAnItem(book1, inventory);
            owner.AddsAnItem(book2, inventory);
            owner.AddsAnItem(book5, inventory);

            System.Console.WriteLine("Printing inventory for sanity check");
            inventory.PrintInventoryInfo();


            //testing of clone 
            BookItem book3 = (BookItem)book2.Clone();
            BookItem book4 = (BookItem)book2.Clone();
            System.Console.WriteLine("Ensuring that the itemid is unique");
            book2.PrintInfo();
            book3.PrintInfo();
            book4.PrintInfo();
            owner.AddsAnItem(book3, inventory);
            owner.AddsAnItem(book4, inventory);

            RegularCustomer customer1 = new RegularCustomer("12345", "RegO1", "MemberFirst", "MemberLast", "123 Important St", "222-222-2222");
            PaidCustomer customer2 = new PaidCustomer("23456", "MEMBER02", 100m, "MemberSecond", "MemberLast", "345 University Ave", "333-333-3333");

            customer1.BuysAnItem(furnitureItem2);
            customer1.BuysAnItem(furnitureItem500Plus);
            System.Console.WriteLine("Ensuring that the 500$ furniture discount is working");
            customer1.PrintInfo();

            customer2.BuysAnItem(furnitureItem2); // Cannot buy as it is already sold. 

            customer2.BuysAnItem(furnitureItem1);
            customer2.BuysAnItem(furnitureItem3);
            customer2.BuysAnItem(book1);
            customer2.BuysAnItem(groceryItem1);
            customer2.BuysAnItem(groceryItem2);

            System.Console.WriteLine("Memberwise customer item list: sanity check + discount check");
            customer2.PrintInfo();

            customer2.BuysAnItem(furnitureItem5); // limit reached. 
            Console.WriteLine();

            Console.WriteLine ("************************************************Challenge 6*************************************************");
            Console.WriteLine();

            //Finding all the furniture items in the inventory using LINQ (Challenge 6)
            Console.WriteLine("******Furniture Items in the inventory******");
            Console.WriteLine();

            var furnitureItems = inventory.Items.Where(item => item is FurnitureItem);
            foreach (FurnitureItem item in furnitureItems)
            {
                item.PrintInfo();
            }
            Console.WriteLine();

            

            Console.WriteLine("******Items that are priced at less than $50******");
            Console.WriteLine();

            var itemsPricedLessThan50 = inventory.Items.Where(item => item.ItemPrice < 50);
            foreach (ShoppingItem item in itemsPricedLessThan50)
            {
                item.PrintInfo();
            }
            Console.WriteLine();



            Console.WriteLine("******Grocery items that are priced at less than $10******");
            Console.WriteLine();

            var groceryItemsPricedLessThan10 = inventory.Items.Where(item => item is GroceryItem && item.ItemPrice < 10);
            foreach (ShoppingItem item in groceryItemsPricedLessThan10)
            {
                item.PrintInfo();
            }
            Console.WriteLine();


            Console.WriteLine("******Book whose author is John Doe******");
            Console.WriteLine();
            var booksByJohnDoe = inventory.Items.Where(item => item is BookItem && ((BookItem)item).Author == "John Doe");
            foreach (ShoppingItem item in booksByJohnDoe)
            {
                item.PrintInfo();
            }
            Console.WriteLine();

            Console.WriteLine("******Sort shop items in descending order by price******");
            Console.WriteLine();
            var sortedItems = inventory.Items.OrderByDescending(item => item.ItemPrice);
            foreach (ShoppingItem item in sortedItems)
            {
                item.PrintInfo();
            }
            Console.WriteLine();

            Console.WriteLine("******Find and sort all books in ascending order by title******");
            Console.WriteLine();
            var books = inventory.Items.Where(item => item is BookItem).OrderBy(item => ((BookItem)item).ItemTitle);
            foreach (ShoppingItem item in books)
            {
                item.PrintInfo();
            }
            Console.WriteLine();

            Console.WriteLine("******Find the costliest item in the inventory******");
            Console.WriteLine();
            var costliestItem = inventory.Items.OrderByDescending(item => item.ItemPrice).First();
            Console.WriteLine("Costliest item: ");
            costliestItem.PrintInfo();
            Console.WriteLine();

            Console.WriteLine("******Find the average cost of grocery item******");
            Console.WriteLine();
            var averageCostOfGroceryItem = inventory.Items.Where(item => item is GroceryItem).Average(item => item.ItemPrice);
            Console.WriteLine("Average cost of grocery item: " + averageCostOfGroceryItem);



            System.Console.ReadLine();
        }
    }
}