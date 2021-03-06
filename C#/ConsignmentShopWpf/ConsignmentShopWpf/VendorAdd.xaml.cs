﻿using System;
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
    /// Interaction logic for VendorAdd.xaml
    /// </summary>
    public partial class VendorAdd : Window
    {
        public static bool Refresh { get; set; }
        Connection con;
        
        ObservableCollection<Vendor> venList;

        public VendorAdd()
        {
            InitializeComponent();
            Refresh = false;
            con = Wellcome.ConnectionInfo;
            GetRefreshDt();
        }

        private void AddVendorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(CommissionTextBox.Text.Contains(".") || !CommissionTextBox.Text.Contains(","))
                {
                    throw new Exception("Please use a ','");
                }
                con.AddVendor((new Vendor
                {
                    FirstName = firstNameTextBox.Text,
                    LastName = lastNameTextBox.Text,
                    Commission = Convert.ToDouble(CommissionTextBox.Text)
                }));

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                CommissionTextBox.Text = "";

                MainWindow.Shop = con.GetShop();
                GetRefreshDt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteVendor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                venList = MainWindow.Shop.ShopVendor;
                int index = venList[dataGridVendor.SelectedIndex].ID;
                con.DeleteItem(index);
                con.DeleteVen(index);
                GetRefreshDt();
                MainWindow.Shop = con.GetShop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetRefreshDt()
        {
            dataGridVendor.ItemsSource = con.GetDtVen().DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Refresh = true;
        }
    }
}
