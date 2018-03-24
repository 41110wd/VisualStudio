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
using System.Windows.Shapes;
using ConsignmentShopWPFClassLibrary;
using System.Collections.ObjectModel;

namespace ConsignmentShopWpf
{
    /// <summary>
    /// Interaction logic for ItemAdd.xaml
    /// </summary>
    public partial class ItemAdd : Window
    {
        public static bool Refresh { get; set; }

        ObservableCollection<Item> itemList;
        ObservableCollection<Vendor> vendorsList;
        Shop shop;
        Connection con;

        public ItemAdd()
        {
            InitializeComponent();

            Refresh = false;
            con = new Connection();
            shop = con.GetShop();
            itemList = shop.ShopItems;
            vendorsList = shop.ShopVendor;

            GetItemDataGrid();
            foreach (Vendor ven in vendorsList)
            {
                itemOwnerComboBox.Items.Add(string.Format("{0} {1}", ven.FirstName, ven.LastName));
            }
            itemOwnerComboBox.SelectedIndex = 0;
        }

        private void itemAddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemPriceTextBox.Text.Contains("."))
                    throw new Exception("Please only use ','");
                con.AddItem(new Item
                {
                    Title = itemTitleTextBox.Text,
                    Description = itemDescriptionTextBox.Text,
                    Price = Convert.ToDouble(itemPriceTextBox.Text),
                    VendorId = Convert.ToInt32(vendorsList[itemOwnerComboBox.SelectedIndex].ID)
                });
                itemTitleTextBox.Text = "";
                itemDescriptionTextBox.Text = "";
                itemPriceTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainWindow.Shop = con.GetShop();

            itemDataGrid.ItemsSource = con.GetDtItem().DefaultView;
        }

        private void itemDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            itemList = con.GetItem();
            con.DeleteItemSpecificID(itemList[itemDataGrid.SelectedIndex].itemID);
            MainWindow.Shop = con.GetShop();
            GetItemDataGrid();
        }

        public void GetItemDataGrid()
        {
            itemDataGrid.ItemsSource = con.GetDtItem().DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Refresh = true;
        }
    }
}
