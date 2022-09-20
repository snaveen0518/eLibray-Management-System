<%@ Page Language="C#" AutoEventWireup="true" CodeFile="findlib.aspx.cs" Inherits="findlib" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <link href="style/Style1.css" rel="stylesheet" type="text/css" />
    <title>Find Laib Card</title>
    
        <script language="javascript" type ="text/javascript" >
    
        //This function is used to fill pin in the parent gird view
        function  FillRID(lnkRID)
        {
                
	        //  window.open('frmFindPincode.aspx','myPopup','height=600,width=900,left=50,top=50,resizable=yes,scrollbars=yes,toolbar=no,status=no');
            opener.document.fh.TxtLibId.value =lnkRID;
            self.close();

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div><table>
        <tr>
            <td colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Search for Library Card" Width="257px" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center" colspan="5" style="height: 5px">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Width="418px" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 126px">
                <b>
                <asp:Label ID="lblcopyfrom" runat="server" Text="Card Holder" Width="100px" Font-Names="Arial" Font-Size="10pt"></asp:Label>
				</b></td>
            <td style="color: red" valign="top">
                *</td>
            <td style="width: 2px">
                :</td>
            <td style="width: 343px">
                <b><font size="2" face="Arial">First Name</font></b><asp:TextBox ID="TxtFirstName" runat="server" MaxLength="100" Width="82px" Font-Names="Arial"></asp:TextBox>
                <b><font face="Arial" size="2">Last Name</font></b>
                <asp:TextBox ID="TxtLastName" runat="server" MaxLength="100" Width="82px" Font-Names="Arial"></asp:TextBox></td>
            <td style="width: 144px">
                <asp:Button ID="btnFind" runat="server" Text="Find" Width="62px" OnClick="btnFind_Click" />&nbsp; &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <div class="PINCODEGridDiv">
                    <asp:GridView ID="gvTeleVerification" runat="server" AutoGenerateColumns="False"
                        Width="100%" OnRowDataBound="gvTeleVerification_RowDataBound" Font-Names="Arial" Font-Size="8pt" AllowPaging="True" OnPageIndexChanging="gvTeleVerification_PageIndexChanging" PageSize="4" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <HeaderStyle CssClass="GridHeader" BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <RowStyle CssClass="GridRow" BackColor="#FFFBD6" ForeColor="#333333" />
                        <AlternatingRowStyle CssClass="GridAlternatingRow" BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRID" runat="server" Text='<%#Eval("LibCardID")%>'></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Lib Card ID
                                </HeaderTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FName" HeaderText="First Name" />
                            <asp:BoundField DataField="LName" HeaderText="Last Name" />
                            <asp:BoundField DataField="City" HeaderText="City" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
