USE [renli_data]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JobInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](50) NULL,
	[DepartId] [int] NULL,
 CONSTRAINT [PK_JobInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[DepartmentInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepName] [nvarchar](50) NULL,	
 CONSTRAINT [PK_DepartmentInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[VacateInfos](--考勤表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[UserId] [int] NULL,--打卡人Id
	[TypeId] [int] NULL,--事假、病假：事假扣100%当天工资、病假扣50%当天工资
	[Money] [int] NULL,--直接算出扣除工资数
	[Remark] [nvarchar](1000) NULL,--直接算出扣除工资数
	[StartTime] [datetime] NULL,--申请时间
	[EndTime] [datetime] NULL,--申请时间
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_VacateInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[ClockingInInfos](--考勤表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[UserId] [int] NULL,--打卡人Id
	[Money] [int] NULL,--金额
	[IsInOut] [int] NULL,--1上班打卡 0下班打卡
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_ClockingInInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[RoyaltyInfos](--提成表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[UserId] [int] NULL,--提成人Id
	[Money] [int] NULL,--金额
	[Remark] [nvarchar](1000) NULL,--备注
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_RoyaltyInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[RewardsInfos](--奖惩表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[JiannChengId] [int] NULL,--奖惩类型  0惩罚  1奖励
	[Money] [int] NULL,--金额
	[UserId] [int] NULL,--奖惩人Id
	[LuRuUserId] [int] NULL,--录入人Id
	[Remark] [nvarchar](1000) NULL,--备注
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_RewardsInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[JobMoveInfos](--职位调动申请表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[NewJob] [int] NULL,--新岗位Id
	[OldJob] [int] NULL,--原有工作Id
	[UserId] [int] NULL,--申请人Id
	[Allow] [int] NULL,--是否通过 0否决 1通过
	[Remark] [nvarchar](1000) NULL,--备注
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_JobMoveInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[RecruitInfos](--招聘申请表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增
	[DepartId] [int] NULL,--部门Id
	[JobId] [int] NULL,--职位Id
	[UserId] [int] NULL,--申请人Id
	[Allow] [int] NULL,--是否通过 0否决 1通过
	[IsHave] [int] NULL,--是否招聘到了员工 0没有 1招到了
	[Remark] [nvarchar](1000) NULL,--备注
	[SubTime] [datetime] NULL,--申请时间	
 CONSTRAINT [PK_RecruitInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RecruitInfos] ADD  CONSTRAINT [DF_RecruitInfos_IsHave]  DEFAULT ((0)) FOR [IsHave]
GO




CREATE TABLE [dbo].[UserInfos](--员工表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增，员工编号
	[UserName] [nvarchar](50) NULL,--姓名
	[Pwd] [nvarchar](100) NULL,--密码
	[Gender] [nvarchar](50) NULL,--性别
	[Mail] [nvarchar](50) NULL,--邮箱
	[Birthday] [datetime] NULL,--生日
	[Marriage] [string] NULL,--婚姻状况
	[Political] [string] NULL,--政治面貌
	[Nation] [nvarchar](100) NULL,--民族
	[Province] [nvarchar](50) NULL,--籍贯
	[HomeAddress] [nvarchar](255) NULL,--住址
	[IDNumber] [nvarchar](255) NULL,--身份证
	[Tel] [nvarchar](50) NULL,--电话
	[College] [nvarchar](255) NULL,--毕业院校
	[Speciality] [nvarchar](255) NULL,--专业
	[KultuLevel] [nvarchar](100) NULL,--学历
	[Salary] [int] NULL,--工资
	[Department] [int] NULL,--部门
	[Job] [int] NULL,--职位
	[Educational] [nvarchar](50) NULL,--学历
	[EntryTime] [datetime] NULL,--入职时间
	[FileName] [nvarchar](255) NULL,--合同名称
	[FilePath] [nvarchar](255) NULL,--合同路径
	[SubTime] [datetime] NULL,--添加时间
 CONSTRAINT [PK_UserInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Pollan](--政治面貌表
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoliticalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pollan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[EducationalSort](--学历表
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EducationalSort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[MaritalStatus](--婚姻状况表
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaritalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO