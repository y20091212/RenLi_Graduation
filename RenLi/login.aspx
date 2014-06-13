<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�û���¼</title>
    <link href="images/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <div id="login">
        <div id="top">
            <div id="top_left">
                <img src="images/login_03.gif" /></div>
            <div id="top_center">
            </div>
        </div>
        <div id="center">
            <div id="center_left">
            </div>
            <div id="center_middle">
                <div id="user">
                   �� ��
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </div>
                <div id="password">
                    �� ��
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lbError" runat="server" Text="" style="color: red;"></asp:Label>
                </div>
                <div id="btn">
                    <asp:LinkButton ID="lbLogin" runat="server" OnClick="lbLogin_Click">��¼</asp:LinkButton>
                    <asp:LinkButton ID="lbClear" runat="server" OnClick="lbClear_Click" >���</asp:LinkButton>
                </div>
            </div>
            <div id="center_right">
            </div>
        </div>
        <div id="down">
            <div id="down_left">
                <div id="inf">
                    <span class="inf_text">�汾��ϢϢ</span> <span class="copyright">������Դϵͳ 2014</span>
                </div>
            </div>
            <div id="down_center">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
