using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserHomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string currentuser = (string)Session["username"];

            if ((string)Session["username"] != currentuser)
            {
                Response.Redirect("~/MainPage.aspx");
            }
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["username"] = Session["username"];
        Response.Redirect("~/Game.aspx");
    }
    
}