<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_change_password.aspx.cs" Inherits="user_change_password"  StylesheetTheme="Theme1" %>

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
	</table><table border="0" cellpadding="0" cellspacing="0" width="1036" id="table1">
	<tr>
		<td width="170" align="left" valign="top">
            <table id="Table5" border="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Button ID="BtnSearchUser" runat="server" Text="Search User" Width="160px" onclick="BtnSearchUser_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnNewUser" runat="server" Text="New User" Width="160px" onclick="BtnNewUser_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 18px">
                        <asp:Button ID="BtnMemberCategory" runat="server" Text="Member Category" Width="160px" onclick="BtnMemberCategory_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 16px">
                        <asp:Button ID="BtnChangePassword" runat="server" Text="Change Password" Width="160px" onclick="BtnChangePassword_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 18px">
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
				
					<tr>
						<td colspan="6" style="height: 22px; background-color: khaki;">
                            <strong>Change Password</strong></td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">&nbsp; &nbsp; &nbsp;&nbsp;</td>
					</tr>
					<tr>
						<td style="height: 16px" colspan="6">
						<table border="0" width="600" id="table3" cellpadding="3">
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px"></td>
		<td align="left" valign="top" style="width: 128px">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top"></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px">
            </td>
		<td align="left" valign="top" style="width: 128px">
            User Name</td>
		<td align="left" valign="top" style="width: 116px">
            <asp:TextBox ID="TxtUserID" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">
                                    </td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px">
            </td>
		<td align="left" valign="top" style="width: 128px">
            Old Password</td>
		<td align="left" valign="top" style="width: 116px">
            <asp:TextBox ID="TxtOldPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">
            </td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px">
            </td>
		<td align="left" valign="top" style="width: 128px"></td>
		<td align="left" valign="top" style="width: 116px"></td>
		<td align="left" valign="top"></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px">
            </td>
		<td align="left" valign="top" style="width: 128px">
            New Password</td>
		<td align="left" valign="top" style="width: 116px">
            <asp:TextBox ID="TxtNewPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top"></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 88px">
            </td>
		<td align="left" valign="top" style="width: 46px">
            </td>
		<td align="left" valign="top" style="width: 128px">
            Verify Password</td>
		<td align="left" valign="top" style="width: 116px">
            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">
            </td>
	</tr>
                            <tr>
                                <td align="left" style="height: 26px; width: 88px;" valign="top">
                                    </td>
                                <td align="left" style="width: 46px; height: 26px" valign="top"></td>
                                <td align="left" style="height: 26px; width: 128px;" valign="top">
                                </td>
                                <td align="left" style="width: 116px; height: 26px" valign="top">
                                    </td>
                                <td align="left" style="height: 26px" valign="top">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width: 88px">
                                    </td>
                                <td align="left" style="width: 46px" valign="top">
                                    </td>
                                <td align="left" valign="top" style="width: 128px">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    </td>
                                <td align="left" valign="top">
                                    </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" style="width: 88px">
                                </td>
                                <td align="left" style="width: 46px" valign="top">
                                </td>
                                <td align="left" valign="top" style="width: 128px">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                </td>
                                <td align="left" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5" style="text-align: center; background-color: khaki;" valign="top">
                                    <asp:Button ID="BtnSubmit" runat="server" Text="Update" onclick="BtnSubmit_Click"/>&nbsp;
                                </td>
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