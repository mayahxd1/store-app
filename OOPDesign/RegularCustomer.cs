using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class RegularCustomer : Customer
    {
        public string RegularCustomerID { get; set; }
        public RegularCustomer(string customerID, string regularCustomerID, string firstName, string lastName, string address, string ssn)
               : base(customerID, firstName, lastName, address, ssn,6)
        {
            RegularCustomerID = regularCustomerID;
           
      
        }

        public virtual void BuysAnItem(ShoppingItem item)
        {
            
            const decimal spendingLimit = 3000m;
            const decimal furnitureDiscountThreshold = 500m;
            const decimal furnitureDiscount = 100m;

            if (item.IsSold)
            {
                Console.WriteLine("Item is already sold.");
                return;
            }

            if (_howManyItemsPurchased >= MaxItems)
            {
                Console.WriteLine("You have already purchased 6 items. You cannot buy more than 6 items. Sorry!");
                return;
            }

            if (_totalAmountSpent >= spendingLimit)
            {
                Console.WriteLine("You have already spent $2000. You cannot spend more than $2000. Sorry!");
                return;
            }

            decimal priceAfterDiscount = item.ItemPrice;
            if (item is FurnitureItem && item.ItemPrice > furnitureDiscountThreshold)
            {
                priceAfterDiscount = item.ItemPrice - furnitureDiscount;
            }   

            if (_totalAmountSpent + item.ItemPrice > spendingLimit)
            {
                Console.WriteLine("You cannot buy this item. It will exceed your spending limit of $3000. Sorry!");
                return;
            }

            _purchasedItems.Add(item);
            _howManyItemsPurchased++;
            _totalAmountSpent += priceAfterDiscount;
            item.IsSold = true;
            Console.WriteLine("Item purchased successfully.");
        }

        public void PrintInfo()
        {
            Console.WriteLine("************************** Regular Customer Infomation **************************");
            base.PrintInfo();
            Console.WriteLine($"Regular Customer ID: {RegularCustomerID}");
        }
    }
}
