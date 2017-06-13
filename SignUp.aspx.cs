using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Validation;
using System.Diagnostics;
public partial class SignUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
       
    }
    protected void submit1_Click(object sender, EventArgs e)
    {
      var field =   FieldValidation();
        if(field == true)
        {
           
        var fnameval = InputTextValidation(fnametext.Text);
        if (fnameval == true)
        {
            var lnameval = InputTextValidation(lnametext.Text);
            if(lnameval == true)
            {
                if (pwdtext1.Text == pwdtext2.Text)
                {

                    using (var context = new Entities6())
                    {
                        var users = from u in context.User_Profile_Details
                                    where u.Username == unametext.Text
                                    select u;
                        if (!users.Any())
                        {
                            User_Profile_Details instance = new User_Profile_Details();
                            User instance2 = new User();
                            User_Bank_Details instance3 = new User_Bank_Details();
                            Account_Details instance4 = new Account_Details();
                            User_Funds instance5 = new User_Funds();
                            Score instance6 = new Score();
                            instance.Fname = fnametext.Text;
                            instance.Lname = lnametext.Text;
                            instance.Username = unametext.Text;
                            instance.Password = pwdtext1.Text;
                            instance.Gender = gender.SelectedValue;
                            instance.Phone = phone.Text;
                            instance.Squestion = squestion.SelectedValue;
                            instance.Sanswer = sanswer.Text;
                            instance.Email = emailtext.Text;
                            instance.Dateofbirth = Convert.ToDateTime(month.SelectedValue + "/" + day.Text + "/" + year.Text);
                            instance2.Username = unametext.Text;
                            instance2.Password = pwdtext1.Text;
                            
                            //context.SaveChanges();
                            instance3.Username = unametext.Text;
                            instance3.Cardnumber = cnum.Text;
                            instance3.Cardname = cname.Text;//swathi added
                           instance3.pin = cvv.Text;
                           instance3.Cardexpiry = month.Text + "/" + year.Text;
                            instance4.Username = unametext.Text;
                            instance4.Bankbalance = 500;
                           instance5.Username = unametext.Text;
                            instance5.Funds = 0;
                            instance6.Username = unametext.Text;

                            context.User_Profile_Details.Add(instance);
                            context.Users.Add(instance2);
                            context.User_Bank_Details.Add(instance3);
                            context.Account_Details.Add(instance4);
                           context.User_Funds.Add(instance5);
                            context.Scores.Add(instance6);
                            context.SaveChanges();

                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Welcome to BlackJack by 24, Please Login with your detailss');</script>");
                            Response.Redirect("~/MainPage.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Username already used. Change the Username');</script>");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Passwords doesn't match');</script>");
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Enter Valid First Name');</script>");
        }
        
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('As already Told, All Fields are mandatory');</script>");
        }

    }
    protected bool FieldValidation()
    {
        if (fnametext.Text != null && lnametext.Text != null && unametext.Text != null && phone.Text != null
            && pwdtext1.Text != null && pwdtext2.Text != null && gender.SelectedValue != "Select"
            && emailtext.Text != null && squestion.Text != null && sanswer.Text != null
            && phone.Text != null && month.SelectedValue != "Select"
            && day.Text != null && year.Text != null)
        {

            return true;
        }
        else
        {
            return false;
        }
     
    }
    protected bool InputTextValidation(string str)
    {
        int count = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (!Char.IsDigit(str[i]))
            {
                continue;
            }
            else
            {
                count++;
            }
        }
        if (count == 0)
            return true;
        else
            return false;
    }
    protected void submit2_Click(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
}   