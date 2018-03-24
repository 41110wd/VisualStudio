using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsignmentShopWPFClassLibrary
{
    public class Connection
    {
        MySqlConnection con;
        ObservableCollection<Vendor> venList;

        public Connection()
        {
            con = new MySqlConnection("Server=127.0.0.1;Port=3306;UID=root;database=consignmentshop");
        }


        public ObservableCollection<Vendor> GetVen()
        {
            venList = new ObservableCollection<Vendor>();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM vendor", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Vendor ven = new Vendor();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        ven.ID = Convert.ToInt32(reader.GetString(0));
                        ven.FirstName = reader.GetString(1);
                        ven.LastName = reader.GetString(2);
                        ven.Commission = reader.GetDouble(3);
                        ven.Money = reader.GetDecimal(4);

                    }
                    venList.Add(ven);
                }
            }
            con.Close();
            return venList;
        }        
        
        public ObservableCollection<Item> GetItem()
        {
            ObservableCollection<Item> itemList = new ObservableCollection<Item>();
            ObservableCollection<Vendor> ven = GetVen();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From item", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item item = new Item();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        item.itemID = Convert.ToInt32(reader.GetString(0));
                        item.Title = reader.GetString(1);
                        item.Description = reader.GetString(2);
                        item.Price = reader.GetDouble(3);
                        item.VendorId = Convert.ToInt32(reader.GetString(5));

                    }
                    itemList.Add(item);
                }
            }

            con.Close();

            return itemList;
        }

        public Shop GetShop()
        {
            Shop shop = new Shop();
            venList = new ObservableCollection<Vendor>();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM vendor", con);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Vendor vend = new Vendor();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        vend.ID = Convert.ToInt32(reader.GetString(0));
                        vend.FirstName = reader.GetString(1);
                        vend.LastName = reader.GetString(2);
                        vend.Commission = reader.GetDouble(3);
                        vend.Money = reader.GetDecimal(4);

                    }
                    venList.Add(vend);
                }
            }
            con.Close();

            ObservableCollection<Item> itemList = new ObservableCollection<Item>();
            //ObservableCollection<Vendor> ven = venList;
            con.Open();

            MySqlCommand cmd2 = new MySqlCommand("Select * From item", con);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    Item item = new Item();

                    for (int i = 0; i < reader2.FieldCount; i++)
                    {
                        item.itemID = Convert.ToInt32(reader2.GetString(0));
                        item.Title = reader2.GetString(1);
                        item.Description = reader2.GetString(2);
                        item.Price = reader2.GetDouble(3);
                        item.VendorId = Convert.ToInt32(reader2.GetString(5));

                    }
                    itemList.Add(item);
                }
            }

            con.Close();

            foreach (Vendor v in venList)
            {
                foreach (Item i in itemList)
                {
                    if (v.ID == i.VendorId)
                    {
                        i.Owner = v;
                    }
                }
            }

            shop.Name = "Harries";
            shop.ShopItems = itemList;
            shop.ShopVendor = venList;
            return shop;
        }

        public DataTable GetDtVen()
        {
            DataTable dt = new DataTable();
            con.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM vendor", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            con.Close();

            return dt;
        }

        public DataTable GetDtItem()
        {
            DataTable dt = new DataTable();
            con.Open();

            MySqlCommand cmd = new MySqlCommand(string.Format("SELECT itemTitle, itemPrice FROM item"), con);
            MySqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            con.Close();

            return dt;
        }

        public void DeleteItem(int id)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM item WHERE itemOwnerId = {id}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteItemSpecificID(int id)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM item WHERE itemId = {id}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddItem(Item item)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(string.Format(
                "INSERT INTO item (itemTitle, itemDescription, itemPrice, itemOwnerId) VALUES ('{0}','{1}','{2}','{3}')"
                , item.Title, item.Description, item.Price.ToString().Replace(",", "."), item.VendorId), con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddVendor(Vendor ven)
        {
            con.Open();

            MySqlCommand cmd = new MySqlCommand(string.Format(
                "Insert Into vendor (venFirstName,venLastName,venCommission) Values ('{0}','{1}','{2}')"
                , ven.FirstName, ven.LastName, ven.Commission.ToString().Replace(",", ".")), con);

            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void DeleteVen(int id)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand($"DELETE FROM vendor WHERE venId = {id}", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateVendor(double venmoney, int id)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand(string.Format(
                "UPDATE vendor SET venMoney = '{0}' Where venId = {1}"
                , venmoney.ToString().Replace(",", "."), id), con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateVendorInit()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE vendor SET venMoney = '0'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
