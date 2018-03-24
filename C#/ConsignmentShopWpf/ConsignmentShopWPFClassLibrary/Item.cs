using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsignmentShopWPFClassLibrary
{
    public class Item
    {
        public int itemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Sold { get; set; } = false;
        public int VendorId { get; set; }
        public Vendor Owner { get; set; }

        public Item()
        {
            
        }

        public Item(string title, string description, double price, bool sold,Vendor owner)
        {
            Title = title;
            Description = description;
            Price = price;
            Sold = sold;
            Owner = owner;
        }

        public override string ToString()
        {
            return string.Format("{0} - € {1}", Title, Price);
        }
    }
}
