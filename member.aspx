<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member.aspx.cs" Inherits="member"  StylesheetTheme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ?</title>
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
            <table id="table2" border="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Button ID="BtnSearchMember" runat="server" Text="Search Member" Width="160px" onclick="BtnSearchMember_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnNewMember" runat="server" Text="New Member" Width="160px" onclick="BtnNewMember_Click" /></td>
                </tr>
                <tr>
                    <td style="height: 18px">
                    </td>
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
				<br/>
					<tr>
						<td colspan="6" style="height: 22px; background-color: khaki;">
                            <strong>Member Matser</strong> &nbsp;&nbsp;
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
            Member ID</td>
		<td align="left" valign="top" style="width: 155px"><asp:TextBox ID="TxtMemberID" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Category</td>
		<td align="left" valign="top">
            <asp:DropDownList ID="DdlCategory" runat="server" Width="150px">
            </asp:DropDownList></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Title</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtTitle" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px"> Date of Birth</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtDOB" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            First Name</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtFName" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Profession</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtProfession" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Middle Name</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtMName" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Qualification</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtQualification" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Last Name</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtLName" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">&nbsp;</td>
		<td align="left" valign="top">&nbsp;</td>
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
		<td align="left" valign="top">
            Address</td>
		<td align="left" valign="top" style="width: 155px">
            <asp:TextBox ID="TxtAddress" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            City</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtCity" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
                            <tr>
                                <td align="left" style="height: 2px" valign="top">
                                    Postal Code</td>
                                <td align="left" style="width: 155px; height: 2px" valign="top">
                                    <asp:TextBox ID="TxtPin" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" style="height: 2px" valign="top">
                                </td>
                                <td align="left" style="width: 116px; height: 2px" valign="top">
                                    Country</td>
                                <td align="left" style="height: 2px" valign="top">
                                    <asp:TextBox ID="TxtCountry" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Email ID</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtEmail" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Mobile</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TxtMobile" runat="server" Width="150px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    Tele Office</td>
                                <td align="left" style="width: 155px" valign="top">
                                    <asp:TextBox ID="TxtTeleOffice" runat="server" Width="150px"></asp:TextBox></td>
                                <td align="left" valign="top">
                                </td>
                                <td align="left" style="width: 116px" valign="top">
                                    Tele Home</td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="TxtTeleHome" runat="server" Width="150px"></asp:TextBox></td>
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
                    &nbsp;? eLibrary Management System <%=System.DateTime.Now.Year.ToString() %> - LMS <font face="Times New Roman">?</font></td>
            </tr>

    </table>
</body>
</html>