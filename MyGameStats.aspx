<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyGameStats.aspx.cs" Inherits="MyGameStats" MasterPageFile="~/UserHomePage.master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="color:lightblue">
        Number of Times Won : <asp:Label ID="winlabel" runat="server" style="color:black"></asp:Label>
    </div>
        <div style="color:lightblue">
            Number of Loses : <asp:Label ID="loselabel" runat="server" style="color:black"></asp:Label>
        </div>
        <div style="color:lightblue">
            Number of BlackJacks : <asp:Label ID="BJLabel" runat="server" style="color:black"></asp:Label>
        </div>
        <div style="margin-left:80px;">
            <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
</asp:Content>
