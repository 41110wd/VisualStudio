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

namespace ConsignmentShopWpf
{
    /// <summary>
    /// Interaction logic for Wellcome.xaml
    /// </summary>
    public partial class Wellcome : Window
    {
        Connection con;
        public static Connection ConnectionInfo { get; set; }

        public Wellcome()
        {
            InitializeComponent();            
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con = new Connection(ServerAdressTextBox.Text, PortTextBox.Text, UserNameTextBox.Text, DataBaseTextBox.Text, PasswordTextBox.Text);
                ConnectionInfo = con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (con.ConnectionCheck())
                Close();

            else
            {
                ServerAdressTextBox.Text = "";
                PortTextBox.Text = "";
                UserNameTextBox.Text = "";
                DataBaseTextBox.Text = "";
                PasswordTextBox.Text = "";
                MessageBox.Show("Error");
            }
        }
    }
}
