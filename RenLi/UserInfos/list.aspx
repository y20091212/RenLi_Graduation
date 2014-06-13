<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="UserInfos_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table class="customer">
        <tr>
            <td class="alt">
                <b>姓名：</b>
            </td>
            <td class="alt">
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click"></asp:Button>
            </td>
        </tr>
    </table>
    <!--Search end-->
    <br />
    <table class="customer">
        <tr>
            <td>
                <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"
                    OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="ID"
                    OnRowDataBound="gridView_RowDataBound" AutoGenerateColumns="false" PageSize="10"
                    RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                        <asp:TemplateField ControlStyle-Width="30" HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserName" HeaderText="姓名" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Gender" HeaderText="性别" SortExpression="Gender" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Mail" HeaderText="邮箱" SortExpression="Mail" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="HomeAddress" HeaderText="住址" SortExpression="HomeAddress"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="IDNumber" HeaderText="身份证" SortExpression="IDNumber" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Speciality" HeaderText="专业" SortExpression="Speciality"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Salary" HeaderText="基本工资" SortExpression="Salary" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="部门" SortExpression="DepartmentName"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="JobName" HeaderText="职位" SortExpression="JobName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="EntryTime" HeaderText="入职时间" SortExpression="EntryTime"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="ID"
                            DataNavigateUrlFormatString="Show.aspx?id={0}" Text="详细" />
                        <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="ID"
                            DataNavigateUrlFormatString="Modify.aspx?id={0}" Text="编辑" />
                        <asp:TemplateField ControlStyle-Width="50" HeaderText="删除" Visible="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
        <tr>
            <td style="width: 1px;">
            </td>
            <td align="left">
                <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
