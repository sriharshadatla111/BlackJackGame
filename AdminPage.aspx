<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminPage" MasterPageFile="~/MasterPage1.master"%>


<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <form id="form1" runat="server" style="color:darkgreen;margin-left:250px">
    
            MinBet:<asp:TextBox ID="Minbet" runat="server"></asp:TextBox>
        MaxBet:<asp:TextBox ID="Maxbet" runat="server"></asp:TextBox>
        <asp:Button ID="AddtoDB" runat="server" Text="PlaceValues" OnClick="AddtoDB_Click" />
        <asp:Button OnClick="RedirectMain_Click" Text="Back" runat="server"/>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
    </form>

        </asp:Content>
