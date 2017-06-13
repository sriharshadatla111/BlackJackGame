<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" MasterPageFile="~/MasterPage1.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Styles/homePage.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style24 {
            color: red;
        }/*}*/
    </style>
    <meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=devic  e-width, initial-scale=1" />
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
  <div class="container-fluid">
    <form id="form1" runat="server">


        <div class="form-group">
            <label for="usernametext">Username : </label>
             <asp:TextBox ID="usernametext" CssClass="form form-control" runat="server"></asp:TextBox><br />
            <label for="passwordtext">Password : </label>&nbsp; <asp:TextBox ID="passwordtext" CssClass="form form-control" runat="server" TextMode="Password"></asp:TextBox><br /><br />
         </div>
        <div>   
            <asp:Button ID="Button1" class="btn btn-default" runat="server" OnClick="Button1_Click" Text="Login" Width="96px" />
        </div>
    </form>
  </div>
<script src="https://code.jquery.com/jquery-3.1.0.min.js" integrity="sha256-cCueBR6CsyA4/9szpPfrX3s49M9vUU5BgtiJj06wt/s=" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</asp:Content>

