<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NoDB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 197px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ServiceChatBDConnectionString %>" SelectCommand="SELECT [username], [geslo], [admin] FROM [Uporabnik]"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <h1 align="center">ServiceChat</h1>
    <br />
    <br />

        <table style="width:50%" align="left">
            <tr>
                <td colspan ="2" class="auto-style3"><h1>Registracija</h1></td>
            </tr>
            <tr> 
                <td colspan="2">   
                        <asp:Label ID="Label3" runat="server" Text="Geslo mora biti dolgo vsaj 8 znakov ter vsebovati vsaj 2 velike črke, 2 znaka in 2 številke!"></asp:Label>
                </td>
            </tr>
            <tr><td><p></p></td></tr>
            <tr>
                <td class="auto-style3">Ime Priimek: </td>
                <td>
                    <asp:TextBox ID="Ime" runat="server" style="margin-left: 6px" Width="171px"></asp:TextBox>
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
                <asp:Button ID="LoginBtnAdmin" runat="server" OnClick="LoginBtnAdmin_Click" Text="Prijava v admin konzolo" Width="166px" />
                <br />
            </td>
        </tr>
    </table>
    </form>
</body></html>
