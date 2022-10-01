using projectportfolio.App_Code;
using System;
using System.Data;

namespace projectportfolio
{
    public partial class Default : System.Web.UI.Page
    {
        ArtFac objArt = new ArtFac();
        SiteFac objSite = new SiteFac();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = objArt.GetNewest();
            DataTable siteDt = objSite.GetAll();
            DataTable linksDt = objArt.GetLinks("Shops");

            foreach (DataRow row in dt.Rows)
            {
                litSlideshow.Text += "<div class='mySlides fade'><img src='../graphic/art/" + row["img"] + "'/></div>";
            }           

            if (siteDt.Rows.Count > 0)
            {
                litSQL.Text += "<img src='../graphic/img/" + siteDt.Rows[0]["img"] + "' width='50px' />" +
                               "<div id='abtcol'><h3> " + siteDt.Rows[0]["title"] + " </h3><p>" + siteDt.Rows[0]["description"] + "</p></div>";
            }
        }
    }
}