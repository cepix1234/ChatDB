<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoDB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 177px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PovezavaPogovor %>" SelectCommand="SELECT [username], [geslo] FROM [Uporabnik]"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <h1 align="center">ChatDB</h1>
    <br />
    <br />

        <table style="width:50%" align="left">
            <tr>
                <td class="auto-style3"><h1>Registracija</h1></td>
            </tr>
            <tr>
                <td class="auto-style3">Ime: </td>
                <td>
                    <asp:TextBox ID="Ime" runat="server" style="margin-left: 6px" Width="149px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Uporabniško ime: </td>
                <td>
                    <asp:TextBox ID="up_ime" runat="server" style="margin-left: 6px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Geslo : </td>
                <td>
                    <asp:TextBox ID="g1" runat="server" TextMode="Password" style="margin-left: 6px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Geslo: </td>
                <td>
                    <asp:TextBox ID="g2" runat="server" TextMode="Password" style="margin-left: 6px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registracij" Width="168px" />
                </td>
            </tr>
        </table>
    <table style="width:50%" align="right">
        <tr>
            <td><td><h1>Prijava</h1></td></td>
        </tr>
        <tr align="left">
            <td align="left">Uporabniško ime: </td>
            <td>
                <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr align="left">
            <td>Geslo: </td>
            <td>
                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr align="left">
            <td></td>
            <td align="left">
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <br />
                <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtn_Click" Text="Prijava" Width="166px" />
                <br />
            </td>
        </tr>
    </table>
    </form>
</body></html>
