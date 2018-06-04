<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Service Sample</title>

    <script language="javascript" type="text/javascript">
<!--

function getStatus() {
    window.status=<% =this.Status %>;
}

-->
    </script>

</head>
<body language="javascript" onload="setInterval('getStatus()',500)">
    <form id="form1" runat="server">
        <div>
            <table id="Table1" bgcolor="#ccccff" cellpadding="0" cellspacing="5" style="z-index: 104;
                left: 10px; width: 700px; position: absolute; top: 17px">
                <tr>
                    <td>
                        <asp:Label ID="lbTitle" runat="server" EnableViewState="False" Font-Bold="True" Font-Names="Verdana"
                            Font-Size="12pt" ForeColor="Navy"> dotConnect for PostgreSQL demo - Using Web Services</asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Note that you have to configure the connection string in the web service's web.config file"
                Font-Names="Verdana" Font-Size="10pt"></asp:Label>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Choose an appropriate query:" Font-Size="10pt"
                    Font-Names="Verdana"></asp:Label>
                <asp:DropDownList ID="cbQuery" runat="server" Width="412px">
                    <asp:ListItem>all employees</asp:ListItem>
                    <asp:ListItem>all departments</asp:ListItem>
                    <asp:ListItem>employees having commission</asp:ListItem>
                    <asp:ListItem>average salary by departments</asp:ListItem>
                    <asp:ListItem>employees' hire by years</asp:ListItem>
                    <asp:ListItem>employees' number by departments</asp:ListItem>
                    <asp:ListItem>employees having no subordinates</asp:ListItem>
                    <asp:ListItem>employees having subordinates and manager</asp:ListItem>
                    <asp:ListItem>employees with minimal salary by departments</asp:ListItem>
                    <asp:ListItem>seniority-salary trend</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="btRetrieve" runat="server" Text="Retrieve" OnClick="btRetrieve_Click"
                    Width="76px" />
            <p>
                <asp:GridView ID="GridView" runat="server" BackColor="#CCCCFF" BorderColor="Black"
                    EnableViewState="False" Font-Names="Verdana" Font-Size="8pt" Width="700px">
                    <HeaderStyle BackColor="#AAAADD" />
                </asp:GridView>
            </p>
            <p>
                <asp:Label ID="lbResult" runat="server" Font-Names="Verdana" Font-Size="10pt" Font-Underline="True"
                    Text="No records selected" Visible="False"></asp:Label></p>
        </div>
    </form>
</body>
</html>
