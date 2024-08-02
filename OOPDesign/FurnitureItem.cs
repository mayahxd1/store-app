using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public class FurnitureItem : ShoppingItem
    {
        
        public decimal _itemHeight;
        public decimal _itemLength;
        public decimal _itemWidth;
        public decimal _itemWeight;

        public decimal ItemHeight
        {
            get { return _itemHeight; }
            set
            {
                if (value > 0)
                {
                    _itemHeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Height should be positive");
                }
            }
        }

        public decimal ItemLength
        {
            get { return _itemLength; }
            set
            {
                if (value > 0)
                {
                    _itemLength = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Length should be positive");
                }
            }
        }

        public decimal ItemWidth
        {
            get { return _itemWidth; }
            set
            {
                if (value > 0)
                {
                    _itemWidth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Width should be positive");
                }
            }
        }

        public decimal ItemWeight
        {
            get { return _itemWeight; }
            set
            {
                if (value > 0)
                {
                    _itemWeight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Weight should be positive");
                }
            }
        }
       


        public FurnitureItem(int itemID, string itemTitle, string itemDescription, decimal itemPrice, decimal itemLength,
            decimal itemHeight, decimal itemWidth, decimal itemWeight) : base(itemID, itemTitle, itemDescription, itemPrice)
        {
            _itemHeight = itemHeight;
            _itemLength = itemLength;
            _itemWidth = itemWidth;
            _itemWeight = itemWeight;
        }

        public override void PrintInfo()
        {       
            Console.WriteLine("************************** Furniture Information **************************");
            Console.WriteLine(" ");
            base.PrintInfo();
            Console.WriteLine("Item Length: " + _itemLength);
            Console.WriteLine("Item Width: " + _itemWidth);
            Console.WriteLine("Item Height: " + _itemHeight);
            Console.WriteLine("Item Weight: " + _itemWeight);         
        }
    }
}
