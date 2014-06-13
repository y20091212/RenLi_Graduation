<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftMenu_ZhuGuan.aspx.cs"
    Inherits="leftMenu_ZhuGuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TreeView ID="SampleTreeView" runat="server">
        <Nodes>
            <asp:TreeNode NavigateUrl="javascript:void(0)" Text="基本信息管理" Expanded="True">
                <asp:TreeNode NavigateUrl="RewardsInfos/list.aspx" Text="员工奖惩记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="ClockingInInfos/list.aspx" Text="月度考勤记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="VacateInfos/list.aspx" Text="员工请假记录" Target="mainFrame">
                </asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="javascript:void(0)" Text="个人信息管理" Expanded="True">
                <asp:TreeNode NavigateUrl="ClockingInInfos/add.aspx" Text="个人签到" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="ClockingInInfos/userlist.aspx" Text="我的签到记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="VacateInfos/add.aspx" Text="请假填写" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="VacateInfos/userlist.aspx" Text="员工请假记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="updatepwd.aspx" Text="个人密码修改" Target="mainFrame"></asp:TreeNode>
                <asp:TreeNode NavigateUrl="JobMoveInfos/add.aspx" Text="职位调动申请" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="JobMoveInfos/list.aspx" Text="职位调动申请列表" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="RewardsInfos/userlist.aspx" Text="我的奖惩记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="Salary/userlist.aspx" Text="我的工资核算" Target="mainFrame">
                </asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode NavigateUrl="javascript:void(0)" Text="部门业务管理" Expanded="True">
                <asp:TreeNode NavigateUrl="RecruitInfos/add.aspx" Text="招聘申请" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="RecruitInfos/list.aspx" Text="招聘申请列表" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="UserInfos/departuserlist.aspx" Text="部门员工列表" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="ClockingInInfos/departlist.aspx" Text="部门员工考勤记录" Target="mainFrame">
                </asp:TreeNode>
                <asp:TreeNode NavigateUrl="JingGao/departlist.aspx" Text="部门考勤分析" Target="mainFrame">
                </asp:TreeNode>
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>
    </form>
</body>
</html>
