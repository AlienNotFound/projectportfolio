using System.Data;
using MySql.Data.MySqlClient;

namespace projectportfolio.App_Code
{
    public class ArtFac
    {
        public int _ID { get; set; } //ID
        public string _title { get; set; } //title
        public string _img { get; set; } //image
        public string _desc { get; set; } //description
        public string _date { get; set; } //date
        public string _cat { get; set; } //category
        public string _tag { get; set; } //tags

        DataAccess DA = new DataAccess();

        public DataTable GetLinks(string PLACE)
        {
            string SQL = $"SELECT * FROM tbl_links WHERE Place IN ('{PLACE}');";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable GetAll()
        {
            string SQL = "SELECT * FROM tbl_allart ORDER BY id;";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable GetNewest()
        {
            string SQL = "SELECT * FROM tbl_allart ORDER BY id DESC LIMIT 8;";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable GetOneRecent(string CAT)
        {
            string SQL = $"SELECT * FROM `tbl_allart` WHERE Category IN ('{CAT}') ORDER BY id DESC LIMIT 1";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable GetAllTags()
        {
            string SQL = "SELECT DISTINCT tag FROM tbl_tags;";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }
        public DataTable GetPager(int PG)
        {
            string SQL = "SELECT * FROM tbl_allart ORDER BY id DESC LIMIT @pg, 8;"; //Finder bestemte rækker at trække ud. Starter ved @pg (den får et tal fra en variable) og trækker to ud derfra
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@pg", PG);
            return DA.GetData(CMD);
        }

        public DataTable GetChosen(int ID)
        {
            string SQL = "SELECT * FROM tbl_allart WHERE ID = @id";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@id", ID);
            return DA.GetData(CMD);
        }

        ///Search and filtering
        public DataTable FilterTag(string TABLE1, string TABLE2, string CELL, string TAG)
        {
            string SQL = $"SELECT * FROM {TABLE1} INNER JOIN {TABLE2} ON tbl_allart.ID = tbl_tags.artID WHERE {TABLE1}.{CELL} = @tag";
            //string SQL = $"SELECT * FROM {TABLE} INNER JOIN tbl_allart ON tbl_allart.ID = tbl_tags.artID WHERE tbl_tags.tag = @tag";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@table1", TABLE1);
            CMD.Parameters.AddWithValue("@table2", TABLE2);
            CMD.Parameters.AddWithValue("@tag", TAG);
            return DA.GetData(CMD);
        }

        public DataTable GetAllCat()
        {
            string SQL = "SELECT * FROM tbl_categories;";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable GetCat(string CAT, int PG)
        {
            string SQL = "SELECT * FROM tbl_allart WHERE Category = @cat ORDER BY id DESC LIMIT @pg, 8";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@cat", CAT);
            CMD.Parameters.AddWithValue("@pg", PG);
            return DA.GetData(CMD);
        }

        public DataTable GetCatPg(string CAT)
        {
            string SQL = $"SELECT * FROM tbl_allart WHERE Category = @cat";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@cat", CAT);
            return DA.GetData(CMD);
        }

        public DataTable FilterCatandSrc(string TABLE1, string TABLE2, string CELL, string TAG, string CAT)
        {
            string SQL = $"SELECT * FROM {TABLE1}" +
                $" INNER JOIN {TABLE2} ON tbl_allart.ID = tbl_tags.artID" +
                $" INNER JOIN tbl_categories ON tbl_allart.Category = tbl_categories.category" +
                $" WHERE tbl_allart.category = {CAT} AND {TABLE1}.{CELL} = {TAG} LIMIT 8";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }

        public DataTable srctest(string TABLE1, string TABLE2, string CELL1, string CELL2, string CELL3, string SRC, string CAT)
        {
            string SQL = $"SELECT * FROM tbl_allart INNER JOIN {TABLE1} ON tbl_allart.{CELL1} = {TABLE1}.{CELL2} WHERE {TABLE2}.{CELL3} LIKE '%{SRC}%' AND tbl_allart.Category = '{CAT}'";
            MySqlCommand CMD = new MySqlCommand(SQL);
            return DA.GetData(CMD);
        }


        ///CMS
        public int Opret()
        {
            string SQL = @"INSERT INTO tbl_allart
                            (title, img, description, date, category)
                            VALUES
                            (@title, @img, @description, @date, @category)";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@title", _title);
            CMD.Parameters.AddWithValue("@img", _img);
            CMD.Parameters.AddWithValue("@description", _desc);
            CMD.Parameters.AddWithValue("@date", _date);
            CMD.Parameters.AddWithValue("@category", _cat);
            return DA.ModifyData(CMD);
        }

        public int Ret()
        {
            string SQL = @"UPDATE tbl_allart SET
                            title = @title,                            
                            description = @description
                            WHERE id = @id";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@id", _ID);
            CMD.Parameters.AddWithValue("@title", _title);
            //CMD.Parameters.AddWithValue("@img", _img);
            CMD.Parameters.AddWithValue("@description", _desc);
            //CMD.Parameters.AddWithValue("@date", _date);
            //CMD.Parameters.AddWithValue("@category", _cat);
            return DA.ModifyData(CMD);
        }

        public int Slet()
        {
            string SQL = @"DELETE FROM tbl_allart WHERE id = @id";
            MySqlCommand CMD = new MySqlCommand(SQL);
            CMD.Parameters.AddWithValue("@id", _ID);
            return DA.ModifyData(CMD);
        }
    }
}