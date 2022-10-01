using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace projectportfolio.App_Code
{
    public class DataAccess
    {
        string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public DataTable GetData(MySqlCommand CMD)
        {

            MySqlConnection objConn = new MySqlConnection(conn);
            CMD.Connection = objConn;

            MySqlDataAdapter objDA = new MySqlDataAdapter();
            objDA.SelectCommand = CMD;

            DataTable dt = new DataTable();
            objDA.Fill(dt);
            return dt;
        }

        //Modify
        public int ModifyData(MySqlCommand CMD)
        {
            MySqlConnection objConn = new MySqlConnection(conn);
            CMD.Connection = objConn;
            objConn.Open();
            int rowsaffected = CMD.ExecuteNonQuery();
            objConn.Close();
            return rowsaffected;
        }
    }
}