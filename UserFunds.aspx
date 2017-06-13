<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserFunds.aspx.cs" Inherits="UserFunds" MasterPageFile="~/UserHomePage.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color:lightblue">
    Available Funds : <asp:Label ID="fundlabel" runat="server"></asp:Label>
    </div>
    <div style="color:lightblue">
        Enter Amount : <asp:TextBox ID="fundtext" runat="server"></asp:TextBox>
    </div>
        <div>
           <span><asp:Button ID="Button1" runat="server" Text="Add Funds" OnClick="Button1_Click" Width="80px" /></span> 
            <asp:Button ID="Button2" runat="server" Text="Back" OnClick="Button2_Click" />
            <asp:Label runat="server" ID="warninglabel" Text=""></asp:Label>
    </div>
</asp:Content>

