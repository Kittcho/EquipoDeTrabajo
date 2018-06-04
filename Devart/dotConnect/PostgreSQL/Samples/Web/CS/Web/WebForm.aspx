<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="WebForm.aspx.cs" Inherits="Web.WebForm" %>
<!doctype HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head>
		<title>WebForm</title>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<table id="Table1" style="z-index: 104; left: 10px; width: 700px; position: absolute; top: 17px; background-color: #ccccff">
				<tr>
					<td>
                        <asp:Label ID="lbTitle" runat="server" EnableViewState="False" Font-Bold="True" Font-Names="Verdana"
                            Font-Size="12pt" ForeColor="Navy"> Using dotConnect for PostgreSQL with ASP .NET</asp:Label></td>
				</tr>
			</table>
			<asp:label id="lbInfo" style="z-index: 111; left: 646px; position: absolute; top: 258px" runat="server" Font-Names="Verdana" Font-Size="10pt" EnableViewState="False" Font-Bold="True" ForeColor="Navy"></asp:label>
			<asp:button id="btInsertRecord" style="z-index: 110; left: 609px; position: absolute; top: 295px" runat="server" Width="100px" Text="Insert record" Visible="False"></asp:button><asp:button id="btUpdate" style="z-index: 109; left: 420px; position: absolute; top: 253px" runat="server" Width="100px" Text="Update"></asp:button><asp:label id="Label2" style="z-index: 108; left: 313px; position: absolute; top: 59px" runat="server" Font-Names="Verdana" Font-Size="10pt" EnableViewState="False" Font-Bold="True" ForeColor="Navy">SQL</asp:label><asp:button id="btFill" style="z-index: 103; left: 311px; position: absolute; top: 253px" runat="server" Text="Fill" width="100px"></asp:button><asp:textbox id="tbSQL" style="z-index: 101; left: 312px; position: absolute; top: 79px" runat="server" Font-Names="Courier New" Width="398px" Height="162px" textmode="MultiLine" wrap="False"></asp:textbox><asp:label id="lbResult" style="z-index: 107; left: 11px; position: absolute; top: 356px" runat="server" Font-Names="Verdana" Font-Size="10pt" EnableViewState="False" Font-Bold="True" ForeColor="Navy" Visible="False">Result</asp:label><asp:label id="lbError" style="z-index: 105; left: 11px; position: absolute; top: 338px" runat="server" Font-Names="Verdana" Font-Size="10pt" EnableViewState="False" Font-Bold="True" ForeColor="Red"></asp:label>
			<table style="border-right: black 1px solid; border-top: black 1px solid; z-index: 102; left: 10px; font: 10pt verdana; border-left: black 1px solid; border-bottom: black 1px solid; position: absolute; top: 58px; background-color: #fffacd" cellspacing="15">
				<tr>
					<td><b>Username </b>
					</td>
					<td><asp:textbox id="tbUsername" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><b>Password </b>
					</td>
					<td><asp:textbox id="tbPassword" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><b>Server</b></td>
					<td><asp:textbox id="tbServer" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td><b>Port</b></td>
					<td>
						<asp:textbox id="tbPort" runat="server"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td><b>Database</b></td>
					<td><asp:textbox id="tbDatabase" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="height: 26px"><asp:label id="lbState" runat="server" EnableViewState="False" Font-Bold="True"></asp:label></td>
					<td align="right" style="height: 26px"><asp:button id="btTest" runat="server" text="Test connection" enableviewstate="False"></asp:button></td>
				</tr>
			</table>
			<br/>
			<br/>
			<asp:datagrid id="dataGrid" style="z-index: 100; left: 10px; position: absolute; top: 377px" runat="server" width="700px" font-names="Verdana" backcolor="#CCCCFF" bordercolor="Black" cellpadding="3" font-size="8pt">
				<headerstyle backcolor="#AAAADD"></headerstyle>
				<columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
					<asp:ButtonColumn Text="Delete" CommandName="Delete">
						<headerstyle width="60px"></headerstyle>
					</asp:ButtonColumn>
				</columns>
			</asp:datagrid></form>
	</body>
</html>
