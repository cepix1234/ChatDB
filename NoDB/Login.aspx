<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoDB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <h1 align="center">NoDB - Prijava</h1>

    <table style="width:30%" align="center">
        <tr>
            <td align="right">Uporabniško ime: </td>
            <td>
                <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">Geslo: </td>
            <td>
                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="left"><br />
                <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtn_Click" Text="Prijava" Width="166px" />
                <br />
            </td>
        </tr>
    </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" SelectCommand="SELECT DISTINCT [CategoryName] FROM [Alphabetical list of products]"></asp:SqlDataSource>
    </form>
</body></html>
