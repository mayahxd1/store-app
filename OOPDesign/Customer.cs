using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class Customer
    {
        public string _customerFirstName;
        public string _customerLastName;
        public string _customerAddress;
        public string _customerSSN;
        public string _customerID;
        public int _howManyItemsPurchased = 0;
        public decimal _totalAmountSpent = 0;
        public List<ShoppingItem> _purchasedItems;
        public int MaxItems { get; set; }


        public Customer(int maxItems)
        {
            _purchasedItems = new List<ShoppingItem>();
            MaxItems = maxItems;
        }

        public Customer(string customerID, string customerFirstName, string customerLastName, string customerAddress, string customerSSN, int maxItems)
        {
            _customerFirstName = customerFirstName;
            _customerLastName = customerLastName;
            _customerAddress = customerAddress;
            _customerSSN = customerSSN;
            _customerID = customerID;
            _howManyItemsPurchased = 0;
            _totalAmountSpent = 0;
            MaxItems = maxItems;
            _purchasedItems = new List<ShoppingItem>();
        }

        public virtual void BuysAnItem(ShoppingItem item)
        {

            if (item.IsSold)
            {
                Console.WriteLine("Item is already sold.");
                return;
            }

            if (_howManyItemsPurchased > 3)
            {
                Console.WriteLine("You have already purchased 3 items. You cannot buy more than 3 items. Sorry!");
                return;
            }

            if (_totalAmountSpent > 2000)
            {
                Console.WriteLine("You have already spent $2000. You cannot spend more than $2000. Sorry!");
                return;
            }

            if (_totalAmountSpent + item.ItemPrice > 2000)
            {
                Console.WriteLine("You cannot buy this item. It will exceed your spending limit of $2000. Sorry!");
                return;
            }

            _purchasedItems.Add(item);
            _howManyItemsPurchased++;
            _totalAmountSpent += item.ItemPrice;
            item.IsSold = true;
            Console.WriteLine("Item purchased successfully.");
        }



        public void PrintInfo()
        {
            Console.WriteLine("************************** Customer Infomation **************************");
            Console.WriteLine(" ");
            Console.WriteLine("Customer ID: " + _customerID);
            Console.WriteLine("Customer Full Name: " + _customerFirstName + " " + _customerLastName);
            Console.WriteLine("Customer Address: " + _customerAddress);
            Console.WriteLine("Customer SSN: " + _customerSSN);
            Console.WriteLine("How Many Items Purchased: " + _howManyItemsPurchased);
            Console.WriteLine("Total Amount Spent: " + _totalAmountSpent);

            Console.WriteLine("Purchased Items:");
            foreach (ShoppingItem item in _purchasedItems)
            {
                item.PrintInfo();
            }

        }
   }
}
