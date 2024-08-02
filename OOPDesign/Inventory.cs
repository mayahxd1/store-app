using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class Inventory
    {
        // List of furniture items
        public List<ShoppingItem> Items;
        private int _itemCount = 0;


        //constructor

        public Inventory()
        {
            Items = new List<ShoppingItem>();
        }

        // *** not needed ***
        //public Inventory(int capacity)
        //{
        //    Items = new ShoppingItem[capacity];
        //}

        //add item to inventory
        public void AddItem(ShoppingItem item)
        {
            Items.Add(item);
        }


        public void PrintInventoryInfo()
        {
            Console.WriteLine("************************** Inventory Infomation **************************");
            Console.WriteLine(" ");

            foreach (ShoppingItem item in Items)
            {
                if (item != null)
                {
                    item.PrintInfo();
                }
            }
        }
    }
}
