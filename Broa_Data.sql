USE [BROA]
GO
/****** Object:  Table [dbo].[OA_EMS_JobCategory]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_JobCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobCategoryName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_JobCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招聘类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_JobCategory', @level2type=N'COLUMN',@level2name=N'JobCategoryName'
GO
/****** Object:  Table [dbo].[OA_EMS_WhetherSettled]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_WhetherSettled](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WhetherSettledName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_WhetherSettled] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否落户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_WhetherSettled', @level2type=N'COLUMN',@level2name=N'WhetherSettledName'
GO
/****** Object:  Table [dbo].[OA_EMS_SettledUnit]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_SettledUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SettledUnitName] [nvarchar](100) NULL,
 CONSTRAINT [PK_OA_EMS_SettledUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_JobStatus]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_JobStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_JobStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_WhetherArchive]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_WhetherArchive](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WhetherArchiveName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_WhetherArchive] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否存档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_WhetherArchive', @level2type=N'COLUMN',@level2name=N'WhetherArchiveName'
GO
/****** Object:  Table [dbo].[OA_EMS_ArchiveUnit]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_ArchiveUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ArchiveUnitName] [nvarchar](100) NULL,
 CONSTRAINT [PK_OA_EMS_ArchiveUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存档单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_ArchiveUnit', @level2type=N'COLUMN',@level2name=N'ArchiveUnitName'
GO
/****** Object:  Table [dbo].[OA_EMS_MaritalStatus]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_MaritalStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaritalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'婚姻状态名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_MaritalStatus', @level2type=N'COLUMN',@level2name=N'MaritalName'
GO
/****** Object:  Table [dbo].[OA_EMS_AccountStatus]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_AccountStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_AccountStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_ContractsUnit]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_ContractsUnit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [nvarchar](100) NULL,
 CONSTRAINT [PK_OA_EMS_ContractsUnit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_UserDegree]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_UserDegree](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DegreeName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_UserDegree] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_Department]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepName] [nvarchar](50) NULL,
	[BusName] [nvarchar](50) NULL,
	[LinkedId] [int] NULL,
	[paixu] [int] NULL,
 CONSTRAINT [PK_OA_EMS_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_HouRegNature]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_HouRegNature](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HouRegName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_ EMS_HouRegNature] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_PolLan]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_PolLan](--政治面貌表
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoliticalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_PolLan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_Job]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_Job](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [nvarchar](50) NULL,
	[Range] [int] NULL,
	[paixu] [int] NULL,
 CONSTRAINT [PK_OA_Job] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_StaffCategories]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_StaffCategories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffCategoriesName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_StaffInfo]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_StaffInfo](--员工信息表
	[ID] [int] IDENTITY(1,1) NOT NULL,--主键，自增，员工编号
	[UserName] [nvarchar](50) NULL,--姓名
	[Password] [nvarchar](100) NULL,--密码
	[Gender] [nvarchar](50) NULL,--性别
	[Mail] [nvarchar](50) NULL,--邮箱
	[Birthday] [datetime] NULL,--生日
	[Marriage] [int] NULL,--婚姻状况
	[Political] [int] NULL,--政治面貌
	[Nation] [nvarchar](100) NULL,--民族
	[Province] [nvarchar](50) NULL,--籍贯
	[HomeAddress] [nvarchar](255) NULL,--住址
	[IDNumber] [nvarchar](255) NULL,--身份证
	[Tel] [nvarchar](50) NULL,--电话
	[College] [nvarchar](255) NULL,--毕业院校
	[Speciality] [nvarchar](255) NULL,--专业
	[KultuLevel] [nvarchar](100) NULL,--学历
	[Salary] [int] NULL,--工资
	[PerformanceSalary] [int] NULL,--绩效工资
	[Department] [int] NULL,--部门
	[Job] [int] NULL,--职位
	[Educational] [nvarchar](50) NULL,--学历
	[EntryTime] [datetime] NULL,--入职时间
	[SubTime] [datetime] NULL,--添加时间
 CONSTRAINT [PK_OA_EMS_StaffInfo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'紧急联系人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'UrgentContact'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务条线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'BusinessDepartment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'婚姻状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'Marital'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'紧急联系人与本人关系' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'UrgentRelationship'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'紧急联系人电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'UrgentTel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'TwoDepartment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'签订合同单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'ContractsUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'招聘类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'JobCategoryID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否落户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'WhetherSettledID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落户单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'SettledUnitID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'落户档案是否存档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'WhetherArchiveID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存档单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OA_EMS_StaffInfo', @level2type=N'COLUMN',@level2name=N'ArchiveUnitID'
GO
/****** Object:  Table [dbo].[OA_EMS_SalesOrganization]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_SalesOrganization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesOrgName] [nvarchar](128) NULL,
 CONSTRAINT [PK_OA_EMS_SalesOrganization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OA_EMS_EducationalSort]    Script Date: 05/28/2014 19:27:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OA_EMS_EducationalSort](--学历表
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_OA_EMS_EducationalSort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_OA_EMS_Department_paixu]    Script Date: 05/28/2014 19:27:21 ******/
ALTER TABLE [dbo].[OA_EMS_Department] ADD  CONSTRAINT [DF_OA_EMS_Department_paixu]  DEFAULT ((0)) FOR [paixu]
GO
/****** Object:  Default [DF_OA_EMS_StaffInfo_StuffRoles]    Script Date: 05/28/2014 19:27:21 ******/
ALTER TABLE [dbo].[OA_EMS_StaffInfo] ADD  CONSTRAINT [DF_OA_EMS_StaffInfo_StuffRoles]  DEFAULT ((1)) FOR [StuffRoles]
GO
/****** Object:  Default [DF_OA_Job_paixu]    Script Date: 05/28/2014 19:27:21 ******/
ALTER TABLE [dbo].[OA_Job] ADD  CONSTRAINT [DF_OA_Job_paixu]  DEFAULT ((0)) FOR [paixu]
GO
