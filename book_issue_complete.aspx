<%@ Page Language="C#" AutoEventWireup="true" CodeFile="book_issue_complete.aspx.cs" Inherits="book_issue_complete"   StylesheetTheme="Theme1"  %>

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
<table border="0" cellpadding="0" cellspacing="0" width="1036" id="table11">
	<tr>
		<td width="170" align="left" valign="top">
            <table id="table2" border="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Button ID="BtnTransaction1" runat="server" Text="Show Transaction" Width="160px" OnClick="BtnTransaction1_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnIssueBook" runat="server" Text="Issue Book" Width="160px" OnClick="BtnIssueBook_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 18px">
                        <asp:Button ID="BtnReceiveBook" runat="server" Text="Receive Book" Width="160px" OnClick="BtnReceiveBook_Click" /></td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="height: 18px">
                    </td>
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
                            &nbsp;&nbsp;<br />
                            <br />
                            <strong>Book issued &nbsp;successfully.</strong><br />
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<br />
                            <br />
                            <br />
                            <br />
                            Book ID : <strong>
                            <span id="span_bookid" runat="server" >
                            
                            </span>
                            
                           
                            </strong><br />
                            <br />
                            Title : <strong>
                            
                           <span id="span_booktitle" runat="server" >
                            
                            </span>
                            
                            </strong><br />
                            <br />
                            Library Card ID :
                            <span id="span_library" runat="server" >
                            
                            </span>
                            <br />
                            <br />
                            Do you want to issue more books then <a href= "transaction_issue_book.aspx?mode=new">Click</a> here<br />
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
                    &nbsp;© eLibrary Management System <%=System.DateTime.Now.Year.ToString() %> - LMS <font face="Times New Roman">™</font></td>
            </tr>

    </table>
</body>
</html> 