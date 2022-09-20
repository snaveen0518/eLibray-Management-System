<%@ Page Language="C#" AutoEventWireup="true" CodeFile="publisher.aspx.cs" Inherits="publisher"  StylesheetTheme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
</head>  
<body>
<form id="fh" runat ="server"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table111" style="font-weight: bold; font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki">
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
		<td align="left" valign="top" style="font-size: 10pt; color: darkgreen; font-family: verdana, arial; height: 28px; background-color: yellow;">&nbsp;Current User : <% Response.Write(Session["uname"]); %>   </td>
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
				<td><asp:Button ID="BtnSearchBook" runat="server" Text="Search Book" Width="160px" onclick="BtnSearchBook_Click"/></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewBook" runat="server" Text="New Book" Width="160px" onclick="BtnNewBook_Click" /></td>
			</tr>
			<tr>
				<td style="height: 18px"><asp:Button ID="BtnSearchAuthor" runat="server" Text="Search Author" Width="160px" onclick="BtnSearchAuthor_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewAuthor" runat="server" Text="New Author" Width="160px" onclick="BtnNewAuthor_Click"/></td>
			</tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSearchPublisher" runat="server" Text="Search publisher" Width="160px" onclick="BtnSearchPublisher_Click"/></td>
            </tr>
            <tr>
                <td style="height: 18px">
                    <asp:Button ID="BtnNewPublisher" runat="server" Text="New publisher" Width="160px" onclick="BtnNewPublisher_Click"/></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
		</table>
		</td>
		<td align="left" valign="top" width="5" bgcolor="#CC9900">&nbsp;</td>
		<td   valign="top" align="center" style="width: 861px">
		
		
				<table border="0" cellpadding="0" cellspacing="0" width="600" id="table4" >
				<br />
					<tr>
						<td colspan="6" style="height: 22px; background-color: khaki;">
                            <strong>Publishers Matser</strong> &nbsp;&nbsp;
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;</td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
						<table border="0" width="600" id="table3" cellpadding="3">
	<tr>
		<td align="left" valign="top">
            Pub ID</td>
		<td align="left" valign="top" style="width: 155px"><asp:TextBox ID="TxtPubId" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top"></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Name</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtName" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Company Name</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtCompnayName" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            </td>
		<td align="left" valign="top" style="width: 155px">
            </td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top">
            </td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Address</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtAddress" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">&nbsp;</td>
		<td align="left" valign="top">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top">
            City</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtCity" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">&nbsp;State</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtState" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Postal Code</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtPin" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top">
            </td>
	</tr>
                            <tr>
                                <td align="left" style="height: 26px" valign="top">
                                    Telephone</td>
                                <td align="left" style="width: 155px; height: 26px" valign="top">
                                    <asp:TextBox ID="TxtTelephone" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" style="height: 26px" valign="top">
                                </td>
                                <td align="left" style="width: 116px; height: 26px" valign="top">
                                    Fax</td>
                                <td align="left" style="height: 26px" valign="top">
                                    <asp:TextBox ID="TxtFax" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Email ID</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtEmailID" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Website</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TxtWebSite" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Comments</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtComments" runat="server" Height="56px" Width="150px" TextMode="MultiLine"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    </td>
                                <td align="left" valign="top">
                                    </td>
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
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Update" onclick="BtnSubmit_Click" /></td>
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

