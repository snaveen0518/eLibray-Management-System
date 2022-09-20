<%@ Page Language="C#" AutoEventWireup="true" CodeFile="author_update.aspx.cs" Inherits="author_update"  StylesheetTheme="Theme1"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS �</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
</head>  
<body>
<form id="fh" runat ="server"> 
<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table1" style="font-weight: bold; font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki">
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
	</table><table border="0" cellpadding="0" cellspacing="0" width="1036" id="table1111">
	<tr>
		<td width="170" align="left" valign="top">
		<table border="0" cellspacing="0" width="100%" id="table2">
			<tr>
				<td><asp:Button ID="BtnSearchBook" runat="server" Text="Search Book" Width="160px" OnClick="BtnSearchBook_Click" /></td>
			</tr>
			<tr>
				<td><asp:Button ID="BtnNewBook" runat="server" Text="New Book" Width="160px" OnClick="BtnNewBook_Click" /></td>
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
		<td   valign="top" width="861" align="center">
		
		
				<table border="0" cellpadding="0" cellspacing="0" width="600" id="table4" >
					<tr>
						<td colspan="6" style="height: 16px">
                            &nbsp;
                            <br />
                            <br />
                            <strong>New book added successfully.</strong><br />
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            <br />
                            <br />
                            <br />
                            Author ID :&nbsp;<strong><span id="span_au_id" runat="server" ></span></strong><br />
                            <br />
                            Author : <strong>
                            
                           <span id="span_authorname" runat="server" >
                            
                            </span>
                            
                            </strong><br />
                            <br />
                            Do you want to add more books then <a href= "author.aspx?mode=new">Click</a> here<br />
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
                            &nbsp; &nbsp; &nbsp;&nbsp;<br />
                            <br />
                            <br />
                            <br />
                            &nbsp;</td>
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
                    &nbsp;� eLibrary Management System <%=System.DateTime.Now.Year.ToString() %> - LMS <font face="Times New Roman">�</font></td>
            </tr>

    </table>
</body>
</html>
