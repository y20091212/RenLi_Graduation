<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="Salary_list" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
    <table class="customer">
        <tr>
            <td class="alt">
                <b>月份：</b>
                <asp:TextBox ID="txtTime" runat="server" Text="" onfocus="eye.datePicker.show(this);"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
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
                        <asp:BoundField DataField="UserName" HeaderText="姓名" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="部门" SortExpression="DepartmentName"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="JobName" HeaderText="职位" SortExpression="JobName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Salary" HeaderText="基本工资" SortExpression="Salary" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="JiangFa" HeaderText="奖罚薪金" SortExpression="JiangFa" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="KaoQin" HeaderText="考勤扣薪" SortExpression="KaoQin" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="QingJia" HeaderText="请假扣薪" SortExpression="QingJia" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Total" HeaderText="月薪" SortExpression="Total" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
