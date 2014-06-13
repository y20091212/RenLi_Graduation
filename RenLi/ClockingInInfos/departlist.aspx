<%@ Page Language="C#" AutoEventWireup="true" CodeFile="departlist.aspx.cs" Inherits="ClockingInInfos_departlist" %>

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
                <b>时间：</b>
            </td>
            <td class="alt">
                <asp:TextBox ID="txtKeyword" runat="server" onfocus="eye.datePicker.show(this);"></asp:TextBox>
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
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="DepName" HeaderText="DepartName" SortExpression="DepName"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="JobName" HeaderText="JobName" SortExpression="JobName"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Money" HeaderText="Money" SortExpression="Money" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="inout" HeaderText="inout" SortExpression="inout" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="SubTime" HeaderText="SubTime" SortExpression="SubTime"
                            ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
