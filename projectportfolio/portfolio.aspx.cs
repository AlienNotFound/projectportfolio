using projectportfolio.App_Code;
using System;
using System.Data;

namespace projectportfolio
{
    public partial class portfolio : System.Web.UI.Page
    {
        ArtFac objArt = new ArtFac();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable lnksDt = objArt.GetLinks("Portfolio");
            if (!IsPostBack)
            {
                foreach (DataRow lnk in lnksDt.Rows)
                {
                    DataTable dt = objArt.GetOneRecent(lnk["link"].ToString());

                    litSQL.Text += "<a href='" + lnk["link"] + ".aspx'><div class='portPgs'><h3>" + lnk["title"] + "</h3><img src='../graphic/art/";

                    if (dt.Rows.Count < 1)
                    {
                        litSQL.Text += "ingenuploadsfundet.jpg";
                    }
                    foreach (DataRow lnkimg in dt.Rows)
                    {
                        litSQL.Text += lnkimg["img"] + "";
                    }
                    litSQL.Text += "' /></div></a>";
                }
            }
        }
    }
}
