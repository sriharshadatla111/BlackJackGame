<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserHomePage.aspx.cs" Inherits="UserHomePage" MasterPageFile="~/UserHomePage.master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="align-items:center">
        <asp:Panel ID="Panel1" runat="server" Visible="true"></asp:Panel>
    </div>
    <div style="align-items:center"">
        <asp:Button ID="Button1" runat="server" Text="Play Now" BorderStyle="Outset" OnClick="Button1_Click" style="height:26px;font-family:Gungsuh;border-radius:10px;margin-left:500px;" />
    </div>

</asp:Content>
