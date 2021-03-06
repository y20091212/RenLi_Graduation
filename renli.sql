USE [master]
GO
/****** Object:  Database [renli_data]    Script Date: 06/01/2014 07:58:39 ******/
CREATE DATABASE [renli_data] ON  PRIMARY 
( NAME = N'renli_data', FILENAME = N'E:\Win7 Toos\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\renli_data.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'renli_data_log', FILENAME = N'E:\Win7 Toos\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\renli_data_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [renli_data] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [renli_data].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [renli_data] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [renli_data] SET ANSI_NULLS OFF
GO
ALTER DATABASE [renli_data] SET ANSI_PADDING OFF
GO
ALTER DATABASE [renli_data] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [renli_data] SET ARITHABORT OFF
GO
ALTER DATABASE [renli_data] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [renli_data] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [renli_data] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [renli_data] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [renli_data] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [renli_data] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [renli_data] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [renli_data] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [renli_data] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [renli_data] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [renli_data] SET  DISABLE_BROKER
GO
ALTER DATABASE [renli_data] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [renli_data] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [renli_data] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [renli_data] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [renli_data] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [renli_data] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [renli_data] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [renli_data] SET  READ_WRITE
GO
ALTER DATABASE [renli_data] SET RECOVERY FULL
GO
ALTER DATABASE [renli_data] SET  MULTI_USER
GO
ALTER DATABASE [renli_data] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [renli_data] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'renli_data', N'ON'
GO
USE [renli_data]
GO
/****** Object:  Table [dbo].[VacateInfos]    Script Date: 06/01/2014 07:58:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VacateInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TypeId] [int] NULL,
	[Money] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_VacateInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Pwd] [nvarchar](100) NULL,
	[Gender] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[Marriage] [nvarchar](100) NULL,
	[Political] [nvarchar](100) NULL,
	[Nation] [nvarchar](100) NULL,
	[Province] [nvarchar](50) NULL,
	[HomeAddress] [nvarchar](255) NULL,
	[IDNumber] [nvarchar](255) NULL,
	[Tel] [nvarchar](50) NULL,
	[College] [nvarchar](255) NULL,
	[Speciality] [nvarchar](255) NULL,
	[KultuLevel] [nvarchar](100) NULL,
	[Salary] [int] NULL,
	[Department] [int] NULL,
	[Job] [int] NULL,
	[Educational] [nvarchar](50) NULL,
	[EntryTime] [datetime] NULL,
	[FileName] [nvarchar](255) NULL,
	[FilePath] [nvarchar](255) NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_UserInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserInfos] ON
INSERT [dbo].[UserInfos] ([ID], [UserName], [Pwd], [Gender], [Mail], [Birthday], [Marriage], [Political], [Nation], [Province], [HomeAddress], [IDNumber], [Tel], [College], [Speciality], [KultuLevel], [Salary], [Department], [Job], [Educational], [EntryTime], [FileName], [FilePath], [SubTime]) VALUES (1, N'admin', N'123', N'男', N'', CAST(0x0000000000000000 AS DateTime), N'已婚', N'0', N'', N'', N'', N'', N'', N'', N'', N'', 6000, 1, 1, N'0', CAST(0x0000A33A00000000 AS DateTime), NULL, NULL, CAST(0x0000A33A00000000 AS DateTime))
INSERT [dbo].[UserInfos] ([ID], [UserName], [Pwd], [Gender], [Mail], [Birthday], [Marriage], [Political], [Nation], [Province], [HomeAddress], [IDNumber], [Tel], [College], [Speciality], [KultuLevel], [Salary], [Department], [Job], [Educational], [EntryTime], [FileName], [FilePath], [SubTime]) VALUES (2, N'小红', N'123456', N'男', N'', CAST(0x0000000000000000 AS DateTime), N'已婚', N'0', N'', N'', N'', N'', N'', N'', N'', N'', 4000, 2, 2, N'0', CAST(0x0000A33B00000000 AS DateTime), N'', N'', CAST(0x0000A33B00828B88 AS DateTime))
INSERT [dbo].[UserInfos] ([ID], [UserName], [Pwd], [Gender], [Mail], [Birthday], [Marriage], [Political], [Nation], [Province], [HomeAddress], [IDNumber], [Tel], [College], [Speciality], [KultuLevel], [Salary], [Department], [Job], [Educational], [EntryTime], [FileName], [FilePath], [SubTime]) VALUES (3, N'小明', N'123456', N'男', N'', CAST(0x0000000000000000 AS DateTime), N'已婚', N'0', N'', N'', N'', N'', N'', N'', N'', N'', 5000, 2, 2, N'0', CAST(0x0000A33B00000000 AS DateTime), N'', N'', CAST(0x0000A33B0083A978 AS DateTime))
SET IDENTITY_INSERT [dbo].[UserInfos] OFF
/****** Object:  Table [dbo].[RoyaltyInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoyaltyInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Money] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_RoyaltyInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardsInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardsInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JiannChengId] [int] NULL,
	[Money] [int] NULL,
	[UserId] [int] NULL,
	[LuRuUserId] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_RewardsInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RewardsInfos] ON
INSERT [dbo].[RewardsInfos] ([ID], [JiannChengId], [Money], [UserId], [LuRuUserId], [Remark], [SubTime]) VALUES (1, 1, 1000, 1, 1, N'', CAST(0x0000A33B00A806D8 AS DateTime))
INSERT [dbo].[RewardsInfos] ([ID], [JiannChengId], [Money], [UserId], [LuRuUserId], [Remark], [SubTime]) VALUES (2, 1, 1000, 1, 1, N'', CAST(0x0000A33B017EB0C0 AS DateTime))
INSERT [dbo].[RewardsInfos] ([ID], [JiannChengId], [Money], [UserId], [LuRuUserId], [Remark], [SubTime]) VALUES (3, 0, -100, 1, 1, N'', CAST(0x0000A33B017EBED0 AS DateTime))
INSERT [dbo].[RewardsInfos] ([ID], [JiannChengId], [Money], [UserId], [LuRuUserId], [Remark], [SubTime]) VALUES (4, 3, 1000, 1, 1, N'', CAST(0x0000A33B017F6088 AS DateTime))
SET IDENTITY_INSERT [dbo].[RewardsInfos] OFF
/****** Object:  Table [dbo].[RecruitInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecruitInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartId] [int] NULL,
	[JobId] [int] NULL,
	[UserId] [int] NULL,
	[Allow] [int] NULL,
	[IsHave] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_RecruitInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RecruitInfos] ON
INSERT [dbo].[RecruitInfos] ([ID], [DepartId], [JobId], [UserId], [Allow], [IsHave], [Remark], [SubTime]) VALUES (1, 2, 2, 1, 3, 3, N'', CAST(0x0000A33A017CA99C AS DateTime))
SET IDENTITY_INSERT [dbo].[RecruitInfos] OFF
/****** Object:  Table [dbo].[Pollan]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pollan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoliticalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pollan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pollan] ON
INSERT [dbo].[Pollan] ([ID], [PoliticalName]) VALUES (1, N'群众')
INSERT [dbo].[Pollan] ([ID], [PoliticalName]) VALUES (2, N'党员')
INSERT [dbo].[Pollan] ([ID], [PoliticalName]) VALUES (3, N'其他党派')
SET IDENTITY_INSERT [dbo].[Pollan] OFF
/****** Object:  Table [dbo].[JobMoveInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobMoveInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NewJob] [int] NULL,
	[OldJob] [int] NULL,
	[UserId] [int] NULL,
	[Allow] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_JobMoveInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[JobMoveInfos] ON
INSERT [dbo].[JobMoveInfos] ([ID], [NewJob], [OldJob], [UserId], [Allow], [Remark], [SubTime]) VALUES (1, 2, 1, 1, 1, N'', CAST(0x0000A33A0138C330 AS DateTime))
SET IDENTITY_INSERT [dbo].[JobMoveInfos] OFF
/****** Object:  Table [dbo].[JobInfos]    Script Date: 06/01/2014 07:58:41 ******/
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
SET IDENTITY_INSERT [dbo].[JobInfos] ON
INSERT [dbo].[JobInfos] ([ID], [JobName], [DepartId]) VALUES (1, N'主管', NULL)
INSERT [dbo].[JobInfos] ([ID], [JobName], [DepartId]) VALUES (2, N'副主管', NULL)
INSERT [dbo].[JobInfos] ([ID], [JobName], [DepartId]) VALUES (3, N'职员', NULL)
SET IDENTITY_INSERT [dbo].[JobInfos] OFF
/****** Object:  Table [dbo].[EducationalSort]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EducationalSort](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EducationalSort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EducationalSort] ON
INSERT [dbo].[EducationalSort] ([Id], [SortName]) VALUES (1, N'高中')
INSERT [dbo].[EducationalSort] ([Id], [SortName]) VALUES (2, N'大学专科')
INSERT [dbo].[EducationalSort] ([Id], [SortName]) VALUES (3, N'大学本科')
INSERT [dbo].[EducationalSort] ([Id], [SortName]) VALUES (4, N'研究生')
SET IDENTITY_INSERT [dbo].[EducationalSort] OFF
/****** Object:  Table [dbo].[DepartmentInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
SET IDENTITY_INSERT [dbo].[DepartmentInfos] ON
INSERT [dbo].[DepartmentInfos] ([ID], [DepName]) VALUES (1, N'人事部')
INSERT [dbo].[DepartmentInfos] ([ID], [DepName]) VALUES (2, N'业务部')
INSERT [dbo].[DepartmentInfos] ([ID], [DepName]) VALUES (3, N'咨询部')
SET IDENTITY_INSERT [dbo].[DepartmentInfos] OFF
/****** Object:  Table [dbo].[ClockingInInfos]    Script Date: 06/01/2014 07:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClockingInInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Money] [int] NULL,
	[IsInOut] [int] NULL,
	[SubTime] [datetime] NULL,
 CONSTRAINT [PK_ClockingInInfos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ClockingInInfos] ON
INSERT [dbo].[ClockingInInfos] ([ID], [UserId], [Money], [IsInOut], [SubTime]) VALUES (1, 1, -160, 0, CAST(0x0000A33B00F47928 AS DateTime))
SET IDENTITY_INSERT [dbo].[ClockingInInfos] OFF
/****** Object:  Default [DF_RecruitInfos_IsHave]    Script Date: 06/01/2014 07:58:41 ******/
ALTER TABLE [dbo].[RecruitInfos] ADD  CONSTRAINT [DF_RecruitInfos_IsHave]  DEFAULT ((0)) FOR [IsHave]
GO
