using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDesign
{
    public enum BookGenre
    {
        Fiction, Romance, Comedy, Biography, NonFiction
    }
    public class BookItem : ShoppingItem
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }

        public BookItem(int itemID, string itemTitle, string itemDescription, decimal itemPrice, string isbn, string author, BookGenre genre)
         : base(itemID, itemTitle, itemDescription, itemPrice)
        {
            ISBN = isbn;
            Author = author;
            Genre = genre;
        }

        public string ItemTitle { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine("************************** Book Information **************************");
            Console.WriteLine(" ");
            base.PrintInfo();
            Console.WriteLine($"Book Genre: {Genre}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"ISBN: {ISBN}");
        }

    }
}
