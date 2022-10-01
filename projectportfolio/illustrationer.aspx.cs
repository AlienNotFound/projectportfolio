using projectportfolio.App_Code;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace projectportfolio
{
    public partial class illustrationer : System.Web.UI.Page
    {
        ArtFac objArt = new ArtFac();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chkFilter.Items.Add(new ListItem("Titel"));
                chkFilter.Items.Add(new ListItem("Tag"));
                chkFilter.SelectedIndex = 0;

                int pageNm = 0;
                int pg = Convert.ToInt32(Request.QueryString["page"]);

                if (pg == 1)
                {
                    pg -= 1;
                }
                else if (pg >= 2)
                {
                    pg -= 1;
                    pg *= 8;
                }

                litSQL.Text += "<div class='tab'>";
                DataTable tabCat = objArt.GetCat("illustrationer", pg);
                foreach (DataRow tab in tabCat.Rows)
                {
                    litSQL.Text += "<a href='post.aspx?id=" + tab["id"] + "'>"+ "<img src='../graphic/art/" + tab["img"] + "' /></a>";
                }
                litSQL.Text += "</div>";

                DataTable allR = objArt.GetCatPg("illustrationer");

                int maxItems = 8; //Hvor mange billeder der max må være på en side
                int maxRows = allR.Rows.Count;

                for (int art = 0; art < maxRows; art += maxItems) //Tæller billederne op, så for hver maxItems (f. eks 4) laver den en ny side og tæller vidre på
                {
                    pageNm++;
                    sidenav.Text += "<a href='illustrationer.aspx?page=" + pageNm + "' />" + pageNm + "</a> ";
                }
            }
        }
        protected void btnSrc_Click(object sender, EventArgs e)
        {
            string srcTxt;
            string tbl1;
            string tbl2;
            string cell1;
            string cell2;
            string cell3;

            if (chkFilter.SelectedIndex == 0)
            {
                litSQL.Text = "";
                sidenav.Text = "";

                srcTxt = txtPortSrc.Text;
                tbl1 = "tbl_categories";
                tbl2 = "tbl_allart";
                cell1 = "category";
                cell2 = "category";
                cell3 = "title";

                DataTable dt = objArt.srctest(tbl1, tbl2, cell1, cell2, cell3, srcTxt, "illustrationer");

                if(dt.Rows.Count == 0)
                {
                    litSQL.Text += "<p>Fandt ingen resultater.</p>";
                }

                litSQL.Text += "<div class='tab'>";
                foreach (DataRow row in dt.Rows)
                {
                    litSQL.Text += "<a href='post.aspx?id=" + row["id"] + "'>" + "<img src='../graphic/art/" + row["img"] + "' /></a>";
                }
                litSQL.Text += "</div>";
            }
            else if (chkFilter.SelectedIndex == 1)
            {
                litSQL.Text = "";
                sidenav.Text = "";

                srcTxt = txtPortSrc.Text;
                tbl1 = "tbl_tags";
                tbl2 = "tbl_tags";
                cell1 = "ID";
                cell2 = "artID";
                cell3 = "tag";

                DataTable dt = objArt.srctest(tbl1, tbl2, cell1, cell2, cell3, srcTxt, "illustrationer");

                if (dt.Rows.Count == 0)
                {
                    litSQL.Text += "<p>Fandt ingen resultater.</p>";
                }

                litSQL.Text += "<div class='tab'>";
                foreach (DataRow row in dt.Rows)
                {
                    litSQL.Text += "<a href='post.aspx?id=" + row["id"] + "'>" + "<img src='../graphic/art/" + row["img"] + "' /></a>";
                }
                litSQL.Text += "</div>";
            }
        }
    }
}