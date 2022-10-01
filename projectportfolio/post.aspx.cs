using projectportfolio.App_Code;
using System;
using System.Data;

namespace projectportfolio
{
    public partial class post : System.Web.UI.Page
    {
        ArtFac objArt = new ArtFac();
        protected void Page_Load(object sender, EventArgs e)
        {
            int pID = Convert.ToInt32(Request.QueryString["id"]);

            Page.GetRouteUrl("post", new { id = pID });
            string type = Page.RouteData.Values["id"] as string;

            DataTable dt = objArt.GetChosen(Convert.ToInt32(pID));

            litContent.Text += type;

            if (dt.Rows.Count > 0)
            {
                litContent.Text += "<h3>" + dt.Rows[0]["title"] + "</h3><p id='date'>" + dt.Rows[0]["date"] + "</p><hr />"
                                    + "<img src='../graphic/art/" + dt.Rows[0]["img"] + "' /></a>"
                                    + "<p>" + dt.Rows[0]["description"] + "</p>";
            }
        }
    }
}