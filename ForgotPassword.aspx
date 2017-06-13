<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword"  MasterPageFile="~/MasterPage1.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .forgotpass
        {
            position:absolute;
            top:25%;
            left:25%;

        }
        .auto-style2 {
            color: #00FF99;
        }
        .auto-style3 {
            color: #009999;
        }
        .auto-style4 {
            color: #FF0000;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">

    <form id="form1" runat="server">
    <div class="forgotpass">
            <span class="auto-style2">Enter Email Id: </span> <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> <br /><br />
            <span class="auto-style3">Question: </span> <asp:Label ID="Label1" runat="server" Text="" CssClass="auto-style3"></asp:Label><br /><br />
            <span class="auto-style4">Answer: </span> <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
    </form>

</asp:Content>