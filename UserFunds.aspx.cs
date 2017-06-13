using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserFunds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string currentuser = (string)Session["username"];
        if(currentuser == (string)Session["username"])
        {   
            using(var context = new Entities6())
            {
                var funds = from u in context.User_Funds
                            where u.Username == currentuser
                            select u;
                var fundvalues = funds.FirstOrDefault();
                
                fundlabel.Text = Convert.ToString(fundvalues.Funds);
            
            }
        }
        else
        {
            //Response.Redirect("~/MainPage.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool validinput = false;

        int f1 = 0;
        try 
        { 
            f1 = Convert.ToInt32(fundtext.Text);
            validinput = true;
            warninglabel.Text = "";
        }
        catch(Exception ex)
        {
            warninglabel.Text = "Enter an integer";
        }

        if(validinput)
        { 
        fundtext.Text = "";
        if (f1 > 500)
        {
            warninglabel.Text = "Please enter the fund valued less than your account balance i.e., 500";

        }
        else
        {
            int id = 0;
            bool val = false;
            using (var context = new Entities6())
            {
                string currentuser = (string)Session["username"];
                var bankacct = from y1 in context.User_Bank_Details
                               where y1.Username == currentuser
                               select y1;
                foreach (var c in bankacct)
                {
                    id = c.UserId;

                    Account_Details ac = new Account_Details();

                    var gameacct = from u1 in context.Account_Details
                                   where u1.UserId == id
                                   select u1;

                    if (gameacct.Any())
                    {
                        val = true;
                    }
                    else
                    {
                        val = false;
                    }
                    if (val)
                    {
                        User_Funds uf = new User_Funds();
                        var temp_instance = from v in context.User_Funds
                                            join k in context.Account_Details on v.UserId equals k.UserId
                                            select v;
                        foreach (var y in temp_instance)
                        {
                            y.Funds += f1;
                        }
                    }
                }
                context.SaveChanges();
                int funds = 0;
                var user = from v in context.User_Funds
                           where v.UserId == id
                           select v;
                foreach (var k in user)
                {
                    funds = k.Funds;
                }
                fundlabel.Text = Convert.ToString(funds);
            }
        }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserHomePage.aspx");
    }
}