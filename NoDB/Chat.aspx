<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="NoDB.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 70px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%">
        <tr>
            <td width="70%">Prijavljeni ste kot: 
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td width="30%">
                <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Odjava" Width="164px" />
            </td>
        </tr>
        <tr>
            <td width="70%" class="auto-style1">
                <asp:TextBox ID="Messages" runat="server" Height="375px" TextMode="MultiLine" Width="775px"></asp:TextBox>
            </td>
            <td width="30%" class="auto-style1">
                <asp:TextBox ID="Users" runat="server" Height="263px" TextMode="MultiLine"></asp:TextBox>
                <br /><br /> 
                <br />
                <asp:Button ID="Refresh" runat="server" OnClick="Refresh_Click" Text="Osveži" Width="168px" />
            </td>
        </tr>
        <tr>
            <td width="70%">
                <asp:TextBox ID="Message" runat="server" Width="773px"></asp:TextBox>
            </td>
            <td width="30%">
                <asp:Button ID="Send" runat="server" OnClick="Send_Click" Text="Pošlji" Width="167px" />
            </td>
        </tr>

    </table>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PovezavaPogovor %>" SelectCommand="SELECT [besedilo], [username] FROM [Pogovor]"></asp:SqlDataSource>


    </form>


</body>
</html>
