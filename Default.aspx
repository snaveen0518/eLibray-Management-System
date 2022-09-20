<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  StylesheetTheme="Theme1" %>
<%@ Register src="header.ascx" tagname="header" tagprefix="h" %>
<%@ Register src="footer.ascx" tagname="footer" tagprefix="f" %>
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
	
	<table border="0" cellpadding="0" cellspacing="0" width="100%" id="table1" >
	<tr>
		
		<td rowspan="6" align="left" valign="top" style="text-align: center">
            <br />
            <br />
            <br />
            <br />
            <br />
            <span style="color: maroon"><strong>
            Welcome to eLibrary</strong></span><br />
            <br />
            The online Library Management System [LMS]<br />
            <br />
            More than <strong><span id="span_bookcount" runat ="server" ></span> </strong> books, <strong><span id="span_membercount" runat="server"></span> </strong> Members.<br />
            <br />
            <br />
            <br />
            <br />
            <strong>
            <span id="span_serverdate" runat ="server" ></span> </strong><br />
            <br />
            <br />
            <br />
            <br />
        </td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 31px; height: 16px">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 31px">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 31px">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 31px">&nbsp;</td>
	</tr>
	<tr>
		<td align="left" valign="top" style="width: 31px; height: 55px;">&nbsp;</td>
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

