<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify.aspx.cs" Inherits="UserInfos_Modify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <table class="customer">
                    <tr>
                        <td class='alt'>
                            员工编号 ：
                        </td>
                        <td>
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            UserName ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Pwd ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Gender ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGender" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="男" Value="男" />
                                <asp:ListItem Enabled="True" Text="女" Value="女" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Mail ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtMail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Birthday ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtBirthday" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Marriage ：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="已婚" Value="已婚" />
                                <asp:ListItem Enabled="True" Text="未婚" Value="未婚" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Political ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPolitical" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Nation ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtNation" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Province ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtProvince" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            HomeAddress ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomeAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            IDNumber ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtIDNumber" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Tel ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            College ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtCollege" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Speciality ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSpeciality" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Salary ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalary" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Department ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Job ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJob" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            Educational ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEducational" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            EntryTime ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtEntryTime" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
                <asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" class="inputbutton"
                    onmouseover="this.className='inputbutton_hover'" onmouseout="this.className='inputbutton'">
                </asp:Button>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
