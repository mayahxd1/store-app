using System;

namespace OOPDesign
{
    public class ShoppingItem : ICloneable
    {
        private int _itemID { get; set; }
        private string ItemTitle { get; set; }
        private string ItemDescription { get; set; }

        private decimal _itemPrice;
        private bool isSold { get; set; }


        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; } 
        }

        public bool IsSold
        {
            get { return isSold; }
            set { isSold = value; } 
        }



        public decimal ItemPrice
        {
            get {return _itemPrice;}

            set
            {
                if (value >= 0 && value <= 1000000)
                {
                    _itemPrice = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price should be between 0 and 10000");
                }
            }
        }

        // constructor
        public ShoppingItem(int item, string title, string description, decimal price)
        {
            ItemID = item;
            ItemTitle = title;
            ItemDescription = description;
            ItemPrice = price;
            IsSold = false;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Item ID: {ItemID}");
            Console.WriteLine($"Item Title: {ItemTitle}");
            Console.WriteLine($"Item Description: {ItemDescription}");
            Console.WriteLine($"Item Price: {ItemPrice}");
            Console.WriteLine($"Item Sold: {(IsSold ? "Yes" : "No")}");
        }

        public object Clone()
        {
            var clone = (ShoppingItem)this.MemberwiseClone();
            clone.ItemID = GenerateNewItemId(); // Ensure you generate a new unique ID
            return clone;
        }

        private static readonly Random random = new Random(); // Static instance

        private int GenerateNewItemId()
        {
            return random.Next(1000, 9999);
        }
    }

}

  
