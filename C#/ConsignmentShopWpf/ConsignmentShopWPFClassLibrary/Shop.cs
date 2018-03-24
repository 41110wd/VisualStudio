using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ConsignmentShopWPFClassLibrary
{
    public class Shop
    {
        public string Name { get; set; }
        public ObservableCollection<Item> ShopItems { get; set; }
        public ObservableCollection<Vendor> ShopVendor { get; set; }

        public Shop(string name = "Barkleys")
        {
            Name = name;
            ShopItems = new ObservableCollection<Item>();
            ShopVendor = new ObservableCollection<Vendor>();
        }
    }
}
