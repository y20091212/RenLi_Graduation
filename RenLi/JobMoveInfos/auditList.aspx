<%@ Page Language="C#" AutoEventWireup="true" CodeFile="auditList.aspx.cs" Inherits="JobMoveInfos_auditList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <table class="customer">
        <tr>
            <td>
                <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"
                    OnPageIndexChanging="gridView_PageIndexChanging" BorderWidth="1px" DataKeyNames="ID"
                    OnRowDataBound="gridView_RowDataBound" AutoGenerateColumns="false" PageSize="10"
                    RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="NewJob" HeaderText="NewJob" SortExpression="NewJob" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="OldJob" HeaderText="OldJob" SortExpression="OldJob" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UserName" HeaderText="UserId" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="SubTime" HeaderText="SubTime" SortExpression="SubTime"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:HyperLinkField HeaderText="审核" ControlStyle-Width="50" DataNavigateUrlFields="ID"
                            DataNavigateUrlFormatString="audit.aspx?id={0}" Text="审核" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

