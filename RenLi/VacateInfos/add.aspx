<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add.aspx.cs" Inherits="VacateInfos_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script src="../js/eye-all.js" type="text/javascript"></script>
    <script src="../js/eye-base.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td>
                <table class="customer">
                    <tr>
                        <td class="alt">
                            TypeId ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTylpe" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="事假" Value="1" />
                                <asp:ListItem Enabled="True" Text="病假" Value="0" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            开始时间 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtSTime" runat="server" Width="70px" onfocus="eye.datePicker.show(this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            结束时间 ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtETime" runat="server" Width="70px" onfocus="eye.datePicker.show(this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            Remark ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server" Width="70px" onfocus="setday(this)"></asp:TextBox>
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
