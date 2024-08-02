using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class StoreOwner
    {
        public string _ownerFirstName;
        public string _ownerLastName;
        public string _ownerAddress;
        public string _ownerSSN;

        public StoreOwner(string ownerFirstName, string ownerLastName, string ownerAddress, string ownerSSN)
        {
            _ownerFirstName = ownerFirstName;
            _ownerLastName = ownerLastName;
            _ownerAddress = ownerAddress;
            _ownerSSN = ownerSSN;
        }


        public void AddsAnItem(ShoppingItem item, Inventory inventory)
        {
            //add item to inventory
            inventory.AddItem(item);
        }


        public void PrintOwnerInfo()
        {
            Console.WriteLine("************************** Owner Infomation **************************");
            Console.WriteLine(" ");
            Console.WriteLine("Owner First Name: " + _ownerFirstName);
            Console.WriteLine("Owner Last Name: " + _ownerLastName);
            Console.WriteLine("Owner Address: " + _ownerAddress);
            Console.WriteLine("Owner SSN: " + _ownerSSN);
        }
    }
}
