using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUD_OPERATION.Models
{
    public class DBManager
    {
      
            SqlConnection con = new SqlConnection("data source=DESKTOP-NNUBLIV\\SQLEXPRESS01;Initial Catalog=KSS_DB;Integrated Security=True;");
        SqlCommand cmd = new SqlCommand();
            public DBManager()
            {
                cmd.Connection = con;
            }
            public bool ExecuteMyNonQuery(string MyCommandText)
            {
                cmd.CommandText = MyCommandText;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int n = cmd.ExecuteNonQuery();
                con.Close();
                return n > 0 ? true : false;
            }
            public DataTable ExecuteMyQuery(string MyCommandText)
            {
                SqlDataAdapter da = new SqlDataAdapter(MyCommandText, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
  