using projectportfolio.App_Code;
using System;
using System.Data;

namespace projectportfolio
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        ArtFac objArt = new ArtFac();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable mnu = objArt.GetLinks("Menu");

                foreach (DataRow row in mnu.Rows)
                {
                    litMenu.Text += "<li><a href='" + row["link"] + "'>" + row["title"] + "</a></li>";
                }

                DataTable shps = objArt.GetLinks("Shops");

                foreach (DataRow row in shps.Rows)
                {
                    ftLnks.Text += "<a href='" + row["link"] + "'><img src='../graphic/icons/" + row["title"] + ".svg' /></a>";
                }

                DataTable ftr = objArt.GetLinks("Footer");

                foreach (DataRow row in ftr.Rows)
                {
                    ftLnks.Text += "<a href='" + row["link"] + "'><img src='../graphic/icons/" + row["title"] + ".svg' /></a>";
                }
            }
        }
    }
}