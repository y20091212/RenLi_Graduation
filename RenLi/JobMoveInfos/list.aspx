<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="JobMoveInfos_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                        <asp:BoundField DataField="NewJob" HeaderText="NewJob" SortExpression="NewJob" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="OldJob" HeaderText="OldJob" SortExpression="OldJob" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="UserName" HeaderText="UserId" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="Status" HeaderText="Allow" SortExpression="Status" ItemStyle-HorizontalAlign="Center" HtmlEncode="False" />
                        <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="SubTime" HeaderText="SubTime" SortExpression="SubTime"
                            ItemStyle-HorizontalAlign="Center" />
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
