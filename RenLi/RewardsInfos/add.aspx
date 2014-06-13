<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="RewardsInfos_add" %>

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
                        <td class="alt">
                            JiannChengId ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJiannChengId" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="奖励" Value="1" />
                                <asp:ListItem Enabled="True" Text="惩罚" Value="0" />
                                <asp:ListItem Enabled="True" Text="项目提成" Value="2" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            Money ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtMoney" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            UserId ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUserInfos" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                                DataTextField="UserName" DataValueField="ID">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:constr %>"
                                SelectCommand="SELECT UserName,ID FROM UserInfos"></asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            Remark ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server" Width="200px"></asp:TextBox>
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
