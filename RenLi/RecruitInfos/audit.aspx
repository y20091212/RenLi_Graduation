<%@ Page Language="C#" AutoEventWireup="true" CodeFile="audit.aspx.cs" Inherits="RecruitInfos_audit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                            ID ：
                        </td>
                        <td>
                            <asp:Label ID="lblID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            DepartId ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDepartment" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            JobId ：
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJob" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="alt">
                            Remark ：
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server" Width="200px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class='alt'>
                            审核 ：
                        </td>
                        <td>
                            <asp:RadioButton ID="rbYes" runat="server" GroupName="audit" Text="通过" Checked="True"/>
                            <asp:RadioButton ID="rbNo" runat="server" GroupName="audit" Text="否决"/>
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
