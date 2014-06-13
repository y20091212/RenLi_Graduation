<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepwd.aspx.cs" Inherits="updatepwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="customer">
        <tr>
            <td class="alt">
                请输入旧密码：
            </td>
            <td>
                <input id="txtOldPwd" type="password" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="alt">
                请输入新密码：
            </td>
            <td>
                <input id="TextBox1" type="password" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="alt">
                请确认新密码：
            </td>
            <td>
                <input id="TextBox2" type="password" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbError" runat="server" Text="" style="color: red;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
