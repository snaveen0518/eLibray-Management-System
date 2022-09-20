<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_publisher.aspx.cs" Inherits="search_publisher"  StylesheetTheme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
</head>  
<body>
<form id="fh" runat ="server"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table1_" style="font-weight: bold; font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki">
	<tr>
		<td height="65" align="left" valign="top" style="background-color: yellow" ><img src ="images/top.gif" alt=""/></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="background-color: khaki">
            <asp:Button ID="BtnHome" runat="server" Text="Home" EnableTheming="True" OnClick="BtnHome_Click"  /><asp:Button ID="BtnAdmin" runat="server"
                Text="Admin"  OnClick="BtnAdmin_Click"/><asp:Button ID="BtnBooks" runat="server" Text="Books" OnClick="BtnBooks_Click"/><asp:Button
                    ID="BtnMembers" runat="server" Text="Members" OnClick="BtnMembers_Click" /><asp:Button ID="BtnLibraryCard" runat="server"
                        Text="Library Card" OnClick="BtnLibraryCard_Click" /><asp:Button ID="BtnTransaction" runat="server" Text="Transaction" OnClick="BtnTransaction_Click" /><asp:Button
                            ID="BtnReports" runat="server" Text="Reports" OnClick="BtnReports_Click" /><asp:Button ID="BtnLogOut" runat="server"
                                Text="Log Out" OnClick="BtnLogOut_Click" /></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="font-size: 10pt; color: darkgreen; font-family: verdana, arial; height: 28px; background-color: yellow;">&nbsp;Current User : <% Response.Write(Session["uname"]); %>  </td>
           </tr>
	<tr>
	<td style="background-color: #ffffcc; font-weight: normal;">
        </td>
	</tr>
	</table>

<table border="0" cellpadding="0" cellspacing="0" width="1036" id="table1">
	<tr>
		<td width="170" align="left" valign="top">
		<table border="0" cellspacing="0" width="100%" id="table2">
			<tr>
				<td><asp:Button ID="BtnSearchBook" runat="server" Text="Search Book" Width="160px" onclick="BtnSearchBook_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewBook" runat="server" Text="New Book" Width="160px" onclick="BtnNewBook_Click" /></td>
			</tr>
			<tr>
				<td style="height: 18px"><asp:Button ID="BtnSearchAuthor" runat="server" Text="Search Author" Width="160px" onclick="BtnSearchAuthor_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewAuthor" runat="server" Text="New Author" Width="160px" onclick="BtnNewAuthor_Click" /></td>
			</tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSearchPublisher" runat="server" Text="Search publisher" Width="160px" onclick="BtnSearchPublisher_Click" /></td>
            </tr>
            <tr>
                <td style="height: 18px">
                    <asp:Button ID="BtnNewPublisher" runat="server" Text="New publisher" Width="160px" onclick="BtnNewPublisher_Click" /></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
		</table>
		</td>
		<td align="left" valign="top" width="5" bgcolor="#CC9900">&nbsp;</td>
		<td   valign="top" width="861" align="center">
		
		
				<table border="0" cellpadding="0" cellspacing="0" width="600" id="table4" >
					<tr>
						<td colspan="6" style="height: 16px">
                            <strong>
                            Search Publishers</strong><br />
                            Pub ID
                            <asp:TextBox ID="TxtPubID" runat="server" Width="96px"></asp:TextBox>
                            &nbsp; Publishers Name
                            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="BtnSubmit" runat="server" Text="Submit" onclick="BtnSubmit_Click" /></td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
						<span id="span_search_result" runat ="server" ></span>
						
						
						</td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
                                Font-Bold="False" Font-Size="9pt" ForeColor="Black" GridLines="None" OnRowDataBound ="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" ShowFooter="True">
                                <FooterStyle BackColor="Tan" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                            </asp:GridView>
                            &nbsp; &nbsp; &nbsp;&nbsp;</td>
					</tr>
				</table>

		
		
		
		
		</td>
	</tr>
</table>

</form>
<table id="table111" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold;
            font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki"
            width="100%">
    <tr>
                <td align="left" style="font-weight: normal; height: 18px; text-align: center" valign="top">
                    &nbsp;© eLibrary Management System <%=System.DateTime.Now.Year.ToString() %> - LMS <font face="Times New Roman">™</font></td>
            </tr>

    </table>
</body>
</html>