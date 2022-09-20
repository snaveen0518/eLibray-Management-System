
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" StylesheetTheme="Theme1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>eLibrary Management System - LMS ™</title>
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="table1" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold;
            font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki"
            width="100%">
            <tr>
                <td align="left" height="65" style="background-color: yellow" valign="top">
                    <img alt="" src="images/top.gif" /></td>
            </tr>
            <tr>
                <td align="center" style="background-color: khaki" valign="top">
                    &nbsp;....... Welcome to eLibrary Mamnagement System ......</td>
            </tr>
            <tr>
                <td align="left" style="font-size: 10pt; color: darkgreen; font-family: verdana, arial;
                    height: 28px; background-color: yellow" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>

                <td style="font-weight: normal; background-color: #ffffcc; text-align: center" align="center">
                    &nbsp;<br />
                    <br />
                    <br />
                    <br />
                    
                    	<table border="0" cellpadding="0" cellspacing="1" width="400" bgcolor="#996600" id="table2"  align="center">
		<tr>
			<td align ="center">
			<table border="0" cellspacing="0" width="100%" bgcolor="#FFFFCC" id="table3" align="center">
				<tr>
					<td style="height: 18px; background-color: khaki" colspan="4">
                        Login to LMS &nbsp; &nbsp;</td>
				</tr>
				<tr>
					<td style="width: 76px">&nbsp;</td>
					<td style="width: 104px">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 76px">&nbsp;</td>
					<td align="left" style="width: 104px">
                        User Name :&nbsp;</td>
					<td align="left">
                        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 76px; height: 28px">&nbsp;</td>
					<td style="height: 28px; width: 104px;" align="left">Password :</td>
					<td style="height: 28px" align="left">
                        <asp:TextBox ID="TxtUserPassword" runat="server" TextMode="Password"></asp:TextBox></td>
					<td style="height: 28px">&nbsp;</td>
				</tr>
				<tr>
					<td style="width: 76px">&nbsp;</td>
					<td style="width: 104px">&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
                    <td colspan="4" style="background-color: khaki" align="center">
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
                        &nbsp; &nbsp;</td>
				</tr>
			</table>
			</td>
		</tr>
	</table>

                    
                    
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            </table>
    <table id="table111" border="0" cellpadding="0" cellspacing="0" style="font-weight: bold;
            font-size: 10pt; color: darkgreen; font-family: verdana, arial; background-color: khaki"
            width="100%">
    <tr>
                <td align="left" style="font-weight: normal; height: 18px; text-align: center" valign="top">
                    &nbsp;© eLibrary Management System <%=System.DateTime.Now.Year.ToString() %>  - LMS <font face="Times New Roman">™</font></td>
            </tr>

    </table>
    	</div>
    </form>
</body>
</html>