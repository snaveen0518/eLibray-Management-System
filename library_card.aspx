<%@ Page Language="C#" AutoEventWireup="true" CodeFile="library_card.aspx.cs" Inherits="library_card"  StylesheetTheme="Theme1"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript">
        function  FindMember()
        {
         

	        window.open('findmember.aspx','myPopup','height=270,width=700,left=420,top=320,resizable=no,scrollbars=no,toolbar=no,status=no');
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
                        <asp:Button ID="BtnSearchLibCard" runat="server" Text="Search Library Card" Width="160px" onclick="BtnSearchLibCard_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BtnNewBook" runat="server" Text="New Library Card" Width="160px" onclick="BtnNewBook_Click" /></td>
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
                            <strong>Library Card Master</strong> &nbsp;&nbsp;
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
            Library Card ID</td>
		<td align="left" valign="top" style="width: 140px"><asp:TextBox ID="TxtLibCardID" runat="server" Width="150px" BackColor="WhiteSmoke" ReadOnly="True"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Create Date</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtCreateDate" runat="server" BackColor="WhiteSmoke" ReadOnly="True"
                Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top" style="height: 4px">
            Member ID</td>
		<td align="left" valign="top" style="width: 140px; height: 4px;">
            <asp:TextBox ID="TxtMemID" runat="server" Width="80px"></asp:TextBox>
            <asp:Button ID="BtnFind" runat="server" Text="Find" Width="48px" OnClick="BtnFind_Click" OnClientClick ="FindMember()" /></td>
		<td align="left" valign="top" style="height: 4px">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px; height: 4px;">
                                    Is Active</td>
		<td align="left" valign="top" style="height: 4px">
                                    <asp:CheckBox ID="ChkIsActive" runat="server" /></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            </td>
		<td align="left" valign="top" style="width: 140px">
            </td>
		<td align="left" valign="top"></td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top">
            </td>
	</tr>
	<tr>
		<td align="left" valign="top">
            Valid From</td>
		<td align="left" valign="top" style="width: 140px">
            <asp:TextBox ID="TxtValidFrom" runat="server" Width="150px"></asp:TextBox></td>
		<td align="left" valign="top">&nbsp;</td>
		<td align="left" valign="top" style="width: 116px">
            Valid Upto</td>
		<td align="left" valign="top">
            <asp:TextBox ID="TxtValidUpto" runat="server" Width="150px"></asp:TextBox></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            </td>
		<td align="left" valign="top" style="width: 140px">
            </td>
		<td align="left" valign="top"></td>
		<td align="left" valign="top" style="width: 116px"></td>
		<td align="left" valign="top"></td>
	</tr>
	<tr>
		<td align="left" valign="top">
            </td>
		<td align="left" valign="top" style="width: 140px">
            </td>
		<td align="left" valign="top"></td>
		<td align="left" valign="top" style="width: 116px">
            </td>
		<td align="left" valign="top">
            </td>
	</tr>
                            <tr>
                                <td align="left" valign="top">
                                    </td>
                                <td align="left" style="width: 140px" valign="top">
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
                                <td align="left" style="width: 140px" valign="top">
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
                                <td align="left" style="width: 140px" valign="top">
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