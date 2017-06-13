using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyGameStats : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var currentuser = Session["username"] as string;
        if(currentuser != null)
        {
            using(var context = new Entities6())
            {
                var userscores = from u in context.Scores
                                 where u.Username == currentuser
                                 select u;
                if(userscores.Any())
                {
                    foreach(var v in userscores)
                    {
                        winlabel.Text = Convert.ToString(v.WinCount);
                        loselabel.Text = Convert.ToString(v.LostCount);
                        BJLabel.Text = Convert.ToString(v.BJCount);
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/MainPage.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserHomePage.aspx");
    }
}