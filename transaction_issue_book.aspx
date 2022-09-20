<%@ Page Language="C#" AutoEventWireup="true" CodeFile="transaction_issue_book.aspx.cs" Inherits="transaction_issue_book"  StylesheetTheme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
            <script language="javascript" type="text/javascript">
        function  FindBook()
        {
         

	        window.open('findbook.aspx','myPopup','height=270,width=700,left=420,top=320,resizable=no,scrollbars=no,toolbar=no,status=no');
	        //window.open('findreviewer.aspx?city='+ TxtReviewer.value ,'myPopup','height=270,width=500,left=420,top=320,resizable=no,scrollbars=no,toolbar=no,status=no');

        }
        function  FindLib()
        {
         

	        window.open('findlib.aspx','myPopup','height=270,width=700,left=420,top=320,resizable=no,scrollbars=no,toolbar=no,status=no');
	        //window.open('findreviewer.aspx?city='+ TxtReviewer.value ,'myPopup','height=270,width=500,left=420,top=320,resizable=no,scrollbars=no,toolbar=no,status=no');

                }

    
    </script>
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
            <table id="table2" border="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Button ID="BtnTransaction11" runat="server" Text="Show Transaction" Width="160px" onclick="BtnTransaction11_Click"/></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnIssueBook" runat="server" Text="Issue Book" Width="160px" onclick="BtnIssueBook_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 18px"><asp:Button ID="BtnReceiveBook" runat="server" Text="Receive Book" Width="160px" onclick="BtnReceiveBook_Click" /></td>
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
		<td   valign="top" align="center" style="width: 861px">
		
		
				<table border="0" cellpadding="0" cellspacing="0" width="600" id="table4" >
				<br />
					<tr>
						<td colspan="6" style="height: 22px; background-color: khaki;">
                            <strong>Library Transaction - Issue of Book</strong> &nbsp;&nbsp;&nbsp;
                        </td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;</td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
						<table border="0" width="600" id="table3" cellpadding="3">
	<tr>
        <td align="left" style="width: 64px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px">
            Transaction ID</td>
		<td align="left" valign="top" style="width: 114px"><asp:TextBox ID="TxtTranID" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top"></td>
	</tr>
                            <tr>
                                <td align="left" style="width: 64px" valign="top">
                                </td>
                                <td align="left" style="width: 135px" valign="top">
                                </td>
                                <td align="left" style="width: 114px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
	<tr>
        <td align="left" style="width: 64px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px">
            Library Card ID</td>
		<td align="left" valign="top" style="width: 114px">
            <asp:TextBox ID="TxtLibId" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;<asp:Button ID="BtnLibCardFind" runat="server" Text="Find Card" Width="96px" OnClick="BtnLibCardFind_Click" OnClientClick ="FindLib()" />&nbsp;</td>
		<td align="left" valign="top">
            </td>
	</tr>
	<tr>
        <td align="left" style="width: 64px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px">
            Book ID</td>
		<td align="left" valign="top" style="width: 114px">
            <asp:TextBox ID="TxtBookId" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;<asp:Button ID="BtnBookFind" runat="server" Text="Find Book" Width="96px" OnClientClick ="FindBook()" OnClick="BtnBookFind_Click" />&nbsp;</td>
		<td align="left" valign="top">
            </td>
	</tr>
                            <tr>
                                <td align="left" style="width: 64px" valign="top">
                                </td>
                                <td align="left" style="width: 135px" valign="top">
                                </td>
                                <td align="left" style="width: 114px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
	<tr>
        <td align="left" style="width: 64px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px">
            Issue Date</td>
		<td align="left" valign="top" style="width: 114px">
            <asp:TextBox ID="TxtIssueDate" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top">&nbsp;</td>
	</tr>
	<tr>
        <td align="left" style="width: 64px; height: 22px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px; height: 22px">
            </td>
		<td align="left" valign="top" style="width: 114px; height: 22px;">
            </td>
		<td align="left" valign="top" style="height: 22px"></td>
		<td align="left" valign="top" style="height: 22px">&nbsp;</td>
	</tr>
	<tr>
        <td align="left" style="width: 64px" valign="top">
        </td>
		<td align="left" valign="top" style="width: 135px">
            </td>
		<td align="left" valign="top" style="width: 114px">
            </td>
		<td align="left" valign="top"></td>
		<td align="left" valign="top">
            </td>
	</tr>
                            <tr>
                                <td align="left" style="width: 64px" valign="top">
                                </td>
                                <td align="left" valign="top" style="width: 135px">
                                    </td>
                                <td align="left" style="width: 114px" valign="top">
                                    </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 64px" valign="top">
                                </td>
                                <td align="left" valign="top" style="width: 135px">
                                    </td>
                                <td align="left" style="width: 114px" valign="top">
                                    </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" valign="top">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 64px" valign="top">
                                </td>
                                <td align="left" valign="top" style="width: 135px">
                                </td>
                                <td align="left" style="width: 114px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5" style="background-color: khaki; text-align: center"
                                    valign="top">
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
</html>