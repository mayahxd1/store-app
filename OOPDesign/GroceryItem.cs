using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public enum GroceryCategory
    {
        Produce, Fruit, MeatFish, Dairy, Beverages
    }
    public class GroceryItem : ShoppingItem 
    {
        public DateTime PackagingDate { get; set; }
        public DateTime ExpiryDate;
        public GroceryCategory Category { get; set; }

        public DateTime expiryDate
        {
            get { return expiryDate; }
            set
            {
                if (value > PackagingDate)
                    expiryDate = value;
                else
                    throw new ArgumentOutOfRangeException("Expiry date should be after packaging date");
            }
        }

        public GroceryItem(int itemID, string itemTitle, string itemDescription, decimal itemPrice, GroceryCategory category, DateTime packagingDate, DateTime expiryDate )
            : base(itemID, itemTitle, itemDescription, itemPrice)
        {
            PackagingDate = packagingDate;
            ExpiryDate = expiryDate;
            Category = category;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("************************** Grocery Information **************************");
            Console.WriteLine(" ");
            base.PrintInfo();
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Packaging Date: {PackagingDate}");
            Console.WriteLine($"Expiry Date: {ExpiryDate}");         
        }

    }
}
