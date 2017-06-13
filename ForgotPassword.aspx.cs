using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = Session["username"] as string;
        string em = TextBox1.Text;
        using (var context = new Entities6())
        {
            var c1 = (from c2 in context.User_Profile_Details
                     where c2.Email == em
                     select c2).ToList();
            foreach (var c in c1)
            {
                Label1.Text = c.Squestion;

                if (TextBox2.Text == c.Sanswer)
                {
                    Label2.Text = "Temporary Password is emailed to your registered mail ID.";
                }
            }
        }
    }
}