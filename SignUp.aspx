<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" MasterPageFile="~/MasterPage1.master" %>

<asp:Content ContentPlaceHolderID ="body" runat="server">
    <form id="form1" runat="server">
    <fieldset style="height: 477px; width: 1003px; align-content:center"" >
    <table>
      
          <tr>
              <td>
       First Name : 
                  </td><td><asp:TextBox ID="fnametext" runat="server" Width="100px"></asp:TextBox>
                  </td>
          </tr>
        <tr>
            <td>
            Last Name : </td><td><asp:TextBox ID="lnametext" runat="server" Width="100px"></asp:TextBox></td></tr>
        <tr><td>
          Enter your Username : </td><td><asp:TextBox ID="unametext" runat="server" Width="100px"></asp:TextBox></td>
        </tr><tr><td>
           Enter your Password : </td><td><asp:TextBox ID="pwdtext1" runat="server" Width="100px" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr><td>Re-type your Password : </td><td><asp:TextBox ID="pwdtext2" runat="server" Width="100px" TextMode="Password"></asp:TextBox>
        </td></tr>
          <tr>
            <td>Gender : </td><td><asp:DropDownList ID="gender" runat="server" Width="100px">
                       <asp:ListItem Text ="Select" Selected="True"></asp:ListItem>
                        <asp:ListItem Text ="Male"></asp:ListItem>
                        <asp:ListItem Text ="Female"></asp:ListItem>
                        <asp:ListItem Text ="Other"></asp:ListItem>
                     </asp:DropDownList></td></tr>
        
        <tr>
            <td>Email : </td><td><asp:TextBox ID="emailtext" runat="server" Width="190px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Select your security question  : </td><td><asp:DropDownList ID="squestion" runat="server" Height="20px" Width="300">
                <asp:ListItem Text ="Select" Selected="True"></asp:ListItem>
                <asp:ListItem Text="What is your favorite food item?"></asp:ListItem>
                <asp:ListItem Text="Which animal do you hate the most?"></asp:ListItem>
                <asp:ListItem Text="What is your best movie?"></asp:ListItem>
                <asp:ListItem Text="What is your mother's maiden name?"></asp:ListItem>
            </asp:DropDownList></td>
       </tr>
        <tr><td>
            Your Answer : </td><td><asp:TextBox ID="sanswer" runat="server" Width="287px"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Your Phone Number : </td><td><asp:TextBox ID="phone" runat="server" Width="100px" ></asp:TextBox> </td>
        </tr>
        <tr><td>Date of Birth :</td><td><asp:DropDownList ID="month" runat="server">
                <asp:ListItem Text ="Month" Selected="True"></asp:ListItem>
                <asp:ListItem Text ="01"></asp:ListItem>
                <asp:ListItem Text ="02"></asp:ListItem>
                <asp:ListItem Text ="03"></asp:ListItem>
                <asp:ListItem Text ="04"></asp:ListItem>
                <asp:ListItem Text ="05"></asp:ListItem>
                <asp:ListItem Text ="06"></asp:ListItem>
                <asp:ListItem Text ="07"></asp:ListItem>
                <asp:ListItem Text ="08"></asp:ListItem>
                <asp:ListItem Text ="09"></asp:ListItem>
                <asp:ListItem Text ="10"></asp:ListItem>
                <asp:ListItem Text ="11"></asp:ListItem>
                <asp:ListItem Text ="12"></asp:ListItem>
                </asp:DropDownList> Day : <asp:TextBox ID="day" runat="server" Width="32px"></asp:TextBox>Year : <asp:TextBox ID="year" runat="server" Width="47px"></asp:TextBox></td>
     
         </tr><tr><td>
            
        
       
           
               </td>
       </tr>
        <tr><td><asp:Label ID="Label3" runat="server" Text="Enter Card Details" style="color:darkgoldenrod"></asp:Label></td></tr>
            <tr>
                    <td>
        

           Enter your Card Number : <asp:TextBox ID="cnum" runat="server" Width="100px"></asp:TextBox>
                                         </td>
        </tr><tr><td>
            Name on your Card : <asp:TextBox ID="cname" runat="server"></asp:TextBox></td></tr>
        <tr>
            <td>Card Expiry : </td></tr>
            <tr><td>Month : <asp:TextBox ID="TextBox1" runat="server" Width="23px"></asp:TextBox>Year : <asp:TextBox ID="TextBox2" runat="server" Width="49px"></asp:TextBox>
        </td></tr><tr><td>
            Enter CVV : <asp:TextBox ID="cvv" runat="server" Width="40px" TextMode="Password"></asp:TextBox></td>
        </tr><tr>
            <td>
            </td>
             </tr><tr>
                 <td>
                     <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" style="color:gainsboro"/>I agree to all the Terms & Conditions
                 </td>
                  </tr><tr><td>
                <p style="color:red;font-family:Gautami">
                <asp:Label ID="Label1" runat="server" Text="All fields are mandatory"></asp:Label></p></td></tr>
                
                <tr><td>
        <asp:Button ID="submit1" runat="server" Text="That's It from my Side" OnClick="submit1_Click" /></td></tr>
        
    </table>    
        </fieldset>
    
    
    </form>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
</asp:Content>

