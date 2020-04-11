
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ERPWebApplication1MVC.Models
{
    public class ItemDbHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["ERPMVCASPConString"].ToString();
            con = new SqlConnection(constring);
        }

        // 1. ********** Insert Item **********
        public bool InsertItem(ItemModel iList)
        {
            connection();
            string query = "INSERT INTO ItemList VALUES('" + iList.Name + "','" + iList.Category + "'," + iList.Price + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // 2. ********** Get All Item List **********
        public List<ItemModel> GetItemList()
        {
            connection();
            List<ItemModel> iList = new List<ItemModel>();

            string query = "SELECT * FROM ItemList";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            adapter.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                iList.Add(new ItemModel
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Name = Convert.ToString(dr["Name"]),
                    Category = Convert.ToString(dr["Category"]),
                    Price = Convert.ToDecimal(dr["Price"])
                });
            }
            return iList;
        }

        // 3. ********** Update Item Details **********
        public bool UpdateItem(ItemModel iList)
        {
            connection();
            string query = "UPDATE ItemList SET Name = '" + iList.Name + "', Category = '" + iList.Category + "', Price = " + iList.Price + " WHERE ID = " + iList.ID;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // 4. ********** Delete Item **********
        public bool DeleteItem(int id)
        {
            connection();
            string query = "DELETE FROM ItemList WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}