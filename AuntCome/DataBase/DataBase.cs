using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace AuntCome.DataBase
{
    public class database
    {
        public MySqlConnection conn=null;

        public MySqlCommand com;

        public MySqlDataAdapter da;
        
        public DataSet ds;

        public DataTable dt;

        public MySqlDataReader dr;

        public void ConnectMySQL()
        {
            conn = new MySqlConnection("Data Source=101.132.148.93;Initial Catalog=auntcoming;User ID=root;Password=wudixiaofendui");
            conn.Open();
        }
        public void CloseMySQL()
        {
            conn.Close();
        }
       public void Insert(string connectstring)
        {
            com = new MySqlCommand();
            com.Connection = conn;
            com.CommandText = connectstring;
            com.ExecuteNonQuery();
        }
        
        public void Update(string connectstring)
        {
            com = new MySqlCommand();
            com.Connection = conn;
            com.CommandText = connectstring;
            com.ExecuteNonQuery();
        }
        public void Find(string connectstring)
        {
            dr = null;
            com = new MySqlCommand(connectstring, conn);
            dr = com.ExecuteReader();
        }
    }
}