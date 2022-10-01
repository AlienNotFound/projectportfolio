using projectportfolio.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Web;

namespace projectportfolio.App_Code
{
    public class SiteFac
    {

        DataAccess DA = new DataAccess();

        public DataTable GetAll()
        {
            string SQL = "SELECT * FROM tbl_about;";
            MySqlCommand CMD = new MySqlCommand(SQL);
            //SqlCommand CMD = new SqlCommand(SQL);
            return DA.GetData(CMD);
        }
    }
}