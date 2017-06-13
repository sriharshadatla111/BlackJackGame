    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MainPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (var context = new Entities6())
        {
            var c1 = (from c2 in context.Scores
                      orderby c2.WinCount descending
                      select new { id = c2.Username, name = c2.WinCount }).Take(3);

            /*GridView1.DataSource = c1.ToList();
            GridView1.DataBind();*/

        } 
            if(!IsPostBack)
        {
            if((string)Session["username"] == usernametext.Text)
            {
                Response.Redirect("~/UserHomePage.aspx");
            }
        }
    }
 
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SignUp.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var context = new Entities6())
        {
            string username = usernametext.Text;
            string password = passwordtext.Text;

            var users = from u in context.Users
                        where u.Username == username && u.Password == password
                        select u;
            var uservalues = users.FirstOrDefault();
            if (uservalues != null)
            {
                Session["username"] = username.ToString();
                Response.Redirect("~/UserHomePage.aspx");
            }

        }
    }
}  