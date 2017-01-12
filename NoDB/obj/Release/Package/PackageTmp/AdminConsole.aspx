<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminConsole.aspx.cs" Inherits="NoDB.AdminConsole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 270px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 270px;
            height: 78px;
        }
        .auto-style4 {
            height: 78px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h4 align="center">
            <asp:Label ID="NaslovnicaL" runat="server"></asp:Label>
        </h4>
    </div>
    <div>

        <table class="auto-style2">
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SQLDSPridobitevUNameInStSporocil" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="229px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="username" HeaderText="username" ReadOnly="True" SortExpression="username" />
                            <asp:BoundField DataField="stSporocil" HeaderText="stSporocil" SortExpression="stSporocil" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    <asp:Label ID="IzbraniUporabnikL" runat="server" Text="IzbraniUporabnik"></asp:Label>
                    &nbsp;<br />
                    <asp:Button ID="IzbrisUporabnikaB" runat="server" OnClick="IzbrisUporabnikaB_Click" Text="Izbriši Uporabnika" />
                    <br />
                    <br />
                    <asp:Button ID="SpremeniVAdminB" runat="server" OnClick="SpremeniVAdminB_Click" Text="Spremeni uporabnika na administratorja" />
                    <br />
                    <br />
                    <asp:Button ID="SpremenivNavadniB" runat="server" OnClick="SpremenivNavadniB_Click" Text="Spremeni uporabnika na navadnega uporabnika" />
                </td>
            </tr>
             <tr>
                <td class="auto-style3">
                </td>
                <td class="auto-style4">
                    <asp:Button ID="OdjavaB" runat="server" OnClick="OdjavaB_Click" Text="Odjava" />
                </td>
            </tr>
        </table>

    </div>
        <asp:SqlDataSource ID="SQLDSPridobitevUNameInStSporocil" runat="server" ConnectionString="<%$ ConnectionStrings:ServiceChatBDConnectionString %>" SelectCommand="SELECT [username], [stSporocil] FROM [Uporabnik] WHERE ([username] NOT LIKE '%' + @username + '%')">
            <SelectParameters>
                <asp:Parameter DefaultValue="admin" Name="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
