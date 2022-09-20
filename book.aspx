<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book.aspx.cs" Inherits="book" StylesheetTheme="Theme1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
</head>  
<body>
<form id="fh" runat ="server"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table11" style="font-weight: bold; font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki">
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
				<td><asp:Button ID="BtnSearchBook" runat="server" Text="Search Book" Width="160px" OnClick="BtnSearchBook_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewBook" runat="server" Text="New Book" Width="160px" /></td>
			</tr>
			<tr>
				<td style="height: 18px"><asp:Button ID="BtnSearchAuthor" runat="server" Text="Search Author" Width="160px" OnClick="BtnSearchAuthor_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewAuthor" runat="server" Text="New Author" Width="160px" OnClick="BtnNewAuthor_Click" /></td>
			</tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSearchPublisher" runat="server" Text="Search publisher" Width="160px" OnClick="BtnSearchPublisher_Click" /></td>
            </tr>
            <tr>
                <td style="height: 18px">
                    <asp:Button ID="BtnNewPublisher" runat="server" Text="New publisher" Width="160px" OnClick="BtnNewPublisher_Click" /></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
		</table>
		</td>
		<td align="left" valign="top" width="5" bgcolor="#CC9900">&nbsp;</td>
		<td   valign="top" align="center" style="width: 847px">
		
		
				<table border="0" cellpadding="0" cellspacing="0" width="600" id="table4" >
				<br />
					<tr>
						<td colspan="6" style="height: 22px; background-color: khaki;">
                            <strong>
                            Book Matser</strong> &nbsp;&nbsp;
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;</td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
						<table border="0" width="600" id="table3" cellpadding="3">
	<tr>
		<td align="left" valign="top">Book ID</td>
		<td align="left" valign="top" style="width: 155px"><asp:TextBox ID="TxtBookId" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Status</td>
		<td align="left" valign="top"><asp:TextBox ID="TxtStatus" runat="server" ReadOnly="True" Width="150px" BackColor="WhiteSmoke">NOT ISSUED</asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            ISBN</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtISBN" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">Title</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtTitle" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Publshers</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:DropDownList ID="DdlPublshers" runat="server" Width="150px">
            </asp:DropDownList></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Year</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtYear" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Authors</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:DropDownList ID="DdlAuthors" runat="server" Width="150px">
            </asp:DropDownList></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">&nbsp;</td>
		<td align="left" valign="top">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Page Count</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtPageCount" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">&nbsp;</td>
		<td align="left" valign="top">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Pre Count</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtPrePageCount" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Post Page</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtPostPageCount" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
                            <tr>
                                <td align="left" style="height: 26px" valign="top">
                                    Binding Type</td>
                                <td align="left" style="width: 155px; height: 26px" valign="top"><asp:DropDownList ID="DdlBuindingType" runat="server" Width="150px">
                                </asp:DropDownList></td>
                                <td align="left" style="height: 26px" valign="top">
                                </td>
                                <td align="left" style="width: 116px; height: 26px" valign="top">
                                    Is Disk</td>
                                <td align="left" style="height: 26px" valign="top">
                                    <asp:CheckBox ID="ChkIsDisk" runat="server" /></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Purchase Date</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtPurchaseDate" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Purchase Source</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TxtPurchaseSource" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Price</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtPrice" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Not for issue</td>
                                <td align="left" valign="top">
                                    <asp:CheckBox ID="ChkNotForIssue" runat="server" /></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Fault</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtFault" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Keywords</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtKeywords" runat="server" Height="56px" Width="150px" TextMode="MultiLine"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Description</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TxtDescription" runat="server" Height="56px" TextMode="MultiLine" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 155px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5" style="text-align: center; background-color: khaki;" valign="top">
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Update" OnClick="BtnSubmit_Click" /></td>
                            </tr>
</table>
                            <br />
                            <br />


						
						</td>
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

