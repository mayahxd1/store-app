using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class PaidCustomer : Customer
    {
        public string MembershipNumber { get; set; }
        public decimal MembershipFee { get; set; }

        public decimal Discount = 0.05m;

        public PaidCustomer(string customerID, string membershipNumber, decimal membershipFee, string firstName, string lastName, string address, string ssn )
               : base(customerID, firstName, lastName, address, ssn, 10)
        {
            MembershipNumber = membershipNumber;
            MembershipFee = membershipFee;
          
           
        }

        public virtual void BuysAnItem(ShoppingItem item)
        {
         
            const decimal spendingLimit = 6000m;
            const decimal furnitureDiscountThreshold = 500m;
            const decimal furnitureDiscount = 100m;
         //   const decimal discountRate = 0.05m;

            if (item.IsSold)
            {
                Console.WriteLine("Item is already sold.");
                return;
            }

            if (_howManyItemsPurchased > MaxItems)
            {
                Console.WriteLine("You have already purchased 10 items. You cannot buy more than 10 items. Sorry!");
                return;
            }

            decimal priceAfterDiscount = item.ItemPrice * (1 - Discount);

            if (item is FurnitureItem && item.ItemPrice > furnitureDiscountThreshold)
            {
                priceAfterDiscount -= furnitureDiscount;
            }

            if (_totalAmountSpent > spendingLimit)
            {
                Console.WriteLine("You have already spent $4000. You cannot spend more than $6000. Sorry!");
                return;
            }

            if (_totalAmountSpent + priceAfterDiscount > spendingLimit)
            {
                Console.WriteLine("You cannot buy this item. It will exceed your spending limit of $6000. Sorry!");
                return;
            }

            _purchasedItems.Add(item);
            _howManyItemsPurchased++;
            _totalAmountSpent += priceAfterDiscount;
            item.IsSold = true;

            Console.WriteLine($"Item purchased successfully. Item ID: {item.ItemID}, Price: {item.ItemPrice}, Price After Discount: {priceAfterDiscount}");

        }

        public void PrintInfo()
        {
            Console.WriteLine("************************** Paid Customer Infomation **************************");
            base.PrintInfo();
            Console.WriteLine($"Membership Number: {MembershipNumber}");
            Console.WriteLine($"Membership Fee: {MembershipFee}");
      
        }
    }
}
