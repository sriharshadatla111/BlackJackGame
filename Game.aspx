<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Game.aspx.cs" Inherits="Game" MasterPageFile="~/UserHomePage.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <br />
        Dealer Points :<asp:Label ID="dealerpoints" runat="server"></asp:Label>
        <br />
    </div>
    <div>
        Enter your Bet :
        <asp:TextBox ID="bettext" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Panel ID="dealerpanel" runat="server" Width="320px" Height="88px"></asp:Panel>
    </div>
    <div>
        <br />
        <br />
    </div>
    <br />
        User Points :<asp:Label ID="userpoints" runat="server"></asp:Label>
    <br />
    <div>
       
        <span>
        <asp:Button ID="Logout" runat="server" Text="LogOut" OnClick="Logout_Click" /></span>
        <asp:Button ID="Hit" runat="server" Text="Hit" OnClick="Hit_Click" />
        <asp:Button ID="Deal" runat="server" Text="Deal" OnClick="Deal_Click" />
        <asp:Button ID="Stand" runat="server" Text="Stand" OnClick="Stand_Click" />
        <asp:Label ID="Result" runat="server" Text=""></asp:Label>
            
    </div>
    <br />
        <div style="align-items: center">
        <asp:Panel ID="userpanel" runat="server" Width="320px" Height="88px">
        </asp:Panel>
        </div>
</asp:Content>
