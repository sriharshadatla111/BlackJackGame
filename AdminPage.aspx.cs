using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AddtoDB_Click(object sender, EventArgs e)
    {

        int minbet = Convert.ToInt32(Minbet.Text);
        int maxbet = Convert.ToInt32(Maxbet.Text);

        using (var context = new Entities6())
        {
            var bets = (from bets1 in context.Admins
                        select bets1);

            if (bets.Any())
            {
                foreach (var bets1 in bets)
                {

                    bets1.A_maxlimit = maxbet;

                    bets1.A_minlimit = minbet;


                }
                context.SaveChanges();
                Label1.Text = "Successfully updated the bet values";
            }
            else
            {
                Admin a = new Admin();
                a.A_uname = "admin";
                a.A_password = "password";
                a.A_minlimit = minbet;
                a.A_maxlimit = maxbet;
                // a.A_lastlogin = TimeZone.CurrentTimeZone;
                context.Admins.Add(a);
                context.SaveChanges();
                Label1.Text = "Successfully updated the bet values for the first time";
    }

        }
    
    }
    protected void RedirectMain_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/MainPage.aspx");

    }
}