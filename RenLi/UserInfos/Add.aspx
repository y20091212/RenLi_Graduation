<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="UserInfos_Add" %>

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
            <td class="alt">
                <table class="customer">
                    <tr>
                        <td class="alt">
                            姓名 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            性别 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGender" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="男" Value="男" />
                                <asp:ListItem Enabled="True" Text="女" Value="女" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            邮件 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtMail" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            生日 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtBirthday" runat="server" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            婚姻状况 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMarriage" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="已婚" Value="已婚" />
                                <asp:ListItem Enabled="True" Text="未婚" Value="未婚" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            政治面貌 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPolitical" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            民族 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtNation" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            籍贯 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtProvince" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            住址 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtHomeAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            身份证号 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtIDNumber" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            电话 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtTel" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            毕业院校 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtCollege" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            专业 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSpeciality" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            工资 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalary" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            部门 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            职位 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJob" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            学历 ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEducational" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            入职时间 ：
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
