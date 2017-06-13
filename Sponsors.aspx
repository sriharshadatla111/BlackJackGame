<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="Sponsors.aspx.cs" Inherits="Sponsors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        img
        {
            height:200px;
            width:200px;
        }
        .spons1
        {
            top:25%;
            position:absolute;
            left:25%;
        }
        .spons2
        {
            top:25%;
            position:absolute;
            left:60%;
        }
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">


    <form id="form1" runat="server">
    
    <div class="spons1">

        <img src="OtherImages/caesars-entertainment.gif" /><br />
        <a href="http://caesarscorporate.com/">Caesars Entertainment Co.</a><br />
     </div>
      <div class="spons2">
        <img src="OtherImages/penn gaming.jpg"/><br />
        <a href="http://www.pngaming.com/">Penn National Gaming Inc.</a>
      </div>
    
    
    </form>
    
</asp:Content>
