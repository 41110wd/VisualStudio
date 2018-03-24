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
using Bin_Hex_Dec_Converter_Class_Lib;

namespace Bin_Hex_Dec_Converter_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox_Result.IsReadOnly = true;
            ComboBox_Type.SelectedIndex=0;
            ComboBox_Type.Items.Add("Decimal     => Binary");
            ComboBox_Type.Items.Add("Binary      => Decimal");
            ComboBox_Type.Items.Add("Decimal     => Hexadecimal");
            ComboBox_Type.Items.Add("Hexadecimal => Decimal");
            ComboBox_Type.Items.Add("Binary      => Hexadecimal");
            ComboBox_Type.Items.Add("Hexadecimal => Binary");
        }

        private void Button_Convert_Click(object sender, RoutedEventArgs e)
        {
            int i = ComboBox_Type.SelectedIndex;
            switch(i)
            {
                case 0:
                    Dec_Bin();
                    break;
                case 1:
                    Bin_Dec();
                    break;
                case 2:
                    Dec_Hex();
                    break;
                case 3:
                    Hex_Dec();
                    break;
                case 4:
                    Bin_Hex();
                    break;
                case 5:
                    Hex_Bin();
                    break;
            }
        }

        private void Dec_Bin()
        {
            try
            {
                if (TextBox_Num.Text != "")
                {
                    TextBox_Result.Text = Converting.GetBin(Convert.ToInt32(TextBox_Num.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void Bin_Dec()
        {
            try
            {
                if (TextBox_Num.Text != "")
                { 
                    int result = Converting.GetDec(Convert.ToInt32(TextBox_Num.Text));
                    if (result == -1)
                        throw new Exception("No valid binary number entered.");
                    TextBox_Result.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void Dec_Hex()
        {
            try
            {
                if (TextBox_Num.Text != "")
                {
                    TextBox_Result.Text = Converting.GetHex_Dec(Convert.ToInt32(TextBox_Num.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void Hex_Dec()
        {
            try
            {
                if (TextBox_Num.Text != "")
                {
                    int result = Converting.GetDec_Hex(TextBox_Num.Text);
                    if (result == -1)
                        throw new Exception("No valid hexadecimal number entered. ");
                    TextBox_Result.Text = result.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void Bin_Hex()
        {
            try
            {
                if (TextBox_Num.Text != "")
                {
                    int result = Converting.GetDec(Convert.ToInt32(TextBox_Num.Text));
                    if (result == -1)
                        throw new Exception("No valid binary was entered. ");
                    TextBox_Result.Text = Converting.GetHex_Dec(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void Hex_Bin()
        {
            try
            {
                if (TextBox_Num.Text != "")
                {
                    int result = Converting.GetDec_Hex(TextBox_Num.Text);
                    if (result == -1)
                    {
                        throw new Exception("No valid hexadecimal number entered. ");
                    }
                    TextBox_Result.Text = Converting.GetBin(result).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TextBox_Num.Text = "";
                TextBox_Result.Text = "";
            }
        }

        private void ComboBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBox_Num.Text = "";
            TextBox_Result.Text = "";
        }

        private void TextBox_Num_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = ComboBox_Type.SelectedIndex;
            switch (i)
            {
                case 0:
                    Dec_Bin();
                    break;
                case 1:
                    Bin_Dec();
                    break;
                case 2:
                    Dec_Hex();
                    break;
                case 3:
                    Hex_Dec();
                    break;
                case 4:
                    Bin_Hex();
                    break;
                case 5:
                    Hex_Bin();
                    break;
            }
        }
    }
}
