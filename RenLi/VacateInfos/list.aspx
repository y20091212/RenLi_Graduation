<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="VacateInfos_list" %>

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
            <td>
                <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"
                    OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="ID"
                    OnRowDataBound="gridView_RowDataBound" AutoGenerateColumns="false" PageSize="10"
                    RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Money" HeaderText="Money" SortExpression="Money" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" SortExpression="StartTime"
                            ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="EndTime" HeaderText="EndTime" SortExpression="EndTime"
                            ItemStyle-HorizontalAlign="Center" />
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
