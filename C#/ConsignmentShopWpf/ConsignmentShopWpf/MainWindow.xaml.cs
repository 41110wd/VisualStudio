using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsignmentShopWPFClassLibrary;
using System.Collections.ObjectModel;

namespace ConsignmentShopWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        decimal storeProfit = 0;
        //Shop shop;
        ObservableCollection<Item> shoppingCartList;
        Connection con; 
        public static Shop Shop { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            con = new Connection();
            con.UpdateVendorInit();
            Shop = con.GetShop();
            shoppingCartList = new ObservableCollection<Item>();
            itemsListBox.ItemsSource = Shop.ShopItems;
            vendorListBox.ItemsSource = Shop.ShopVendor;
        }

        private void addToCartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!shoppingCartList.Contains(itemsListBox.SelectedItem))
                {
                    shoppingCartList.Add((Item)itemsListBox.SelectedItem);
                    shoppingCartListBox.ItemsSource = shoppingCartList;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeFromCartButton_Click(object sender, RoutedEventArgs e)
        {
            Item selectedItem = (Item)shoppingCartListBox.SelectedItem;
            selectedItem.Sold = false;
            shoppingCartList.Remove(selectedItem);         
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Item item in shoppingCartList)
            {
                item.Sold = true;
            }

            itemsListBox.ItemsSource = Shop.ShopItems.Where(x => !x.Sold);

            foreach (Item item in shoppingCartList)
            {
                item.Owner.Money += (decimal)(item.Owner.Commission*item.Price);
                con.UpdateVendor((double)item.Owner.Money,item.Owner.ID);
                storeProfit += (1-(decimal)item.Owner.Commission)*(decimal)item.Price;
            }
            Shop.ShopVendor = con.GetVen();
            vendorListBox.ItemsSource = Shop.ShopVendor;
            StoreProfitValueLabel.Content = "€ "+storeProfit;
            shoppingCartList.Clear();

        }

        private void vendorAddButton_Click(object sender, RoutedEventArgs e)
        {
            VendorAdd vendorAdd = new VendorAdd();
            vendorAdd.ShowDialog();
            while (true)
            {
                if (VendorAdd.Refresh)
                {
                    //Shop = con.GetShop();
                    vendorListBox.ItemsSource = Shop.ShopVendor;
                    break;
                }
            }
        }

        private void editItemButton_Click(object sender, RoutedEventArgs e)
        {
            ItemAdd itemadd = new ItemAdd();
            itemadd.ShowDialog();
            while(true)
            {
                if(ItemAdd.Refresh)
                {
                    //Shop = con.GetShop();
                    itemsListBox.ItemsSource = Shop.ShopItems.Where(x=>!x.Sold);
                    break;
                }
            }
        }
    }
}
