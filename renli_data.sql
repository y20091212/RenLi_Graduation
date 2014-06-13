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





CREATE TABLE [dbo].[VacateInfos](--���ڱ�
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[UserId] [int] NULL,--����Id
	[TypeId] [int] NULL,--�¼١����٣��¼ٿ�100%���칤�ʡ����ٿ�50%���칤��
	[Money] [int] NULL,--ֱ������۳�������
	[Remark] [nvarchar](1000) NULL,--ֱ������۳�������
	[StartTime] [datetime] NULL,--����ʱ��
	[EndTime] [datetime] NULL,--����ʱ��
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_VacateInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[ClockingInInfos](--���ڱ�
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[UserId] [int] NULL,--����Id
	[Money] [int] NULL,--���
	[IsInOut] [int] NULL,--1�ϰ�� 0�°��
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_ClockingInInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[RoyaltyInfos](--��ɱ�
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[UserId] [int] NULL,--�����Id
	[Money] [int] NULL,--���
	[Remark] [nvarchar](1000) NULL,--��ע
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_RoyaltyInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[RewardsInfos](--���ͱ�
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[JiannChengId] [int] NULL,--��������  0�ͷ�  1����
	[Money] [int] NULL,--���
	[UserId] [int] NULL,--������Id
	[LuRuUserId] [int] NULL,--¼����Id
	[Remark] [nvarchar](1000) NULL,--��ע
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_RewardsInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[JobMoveInfos](--ְλ���������
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[NewJob] [int] NULL,--�¸�λId
	[OldJob] [int] NULL,--ԭ�й���Id
	[UserId] [int] NULL,--������Id
	[Allow] [int] NULL,--�Ƿ�ͨ�� 0��� 1ͨ��
	[Remark] [nvarchar](1000) NULL,--��ע
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_JobMoveInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




CREATE TABLE [dbo].[RecruitInfos](--��Ƹ�����
	[ID] [int] IDENTITY(1,1) NOT NULL,--����������
	[DepartId] [int] NULL,--����Id
	[JobId] [int] NULL,--ְλId
	[UserId] [int] NULL,--������Id
	[Allow] [int] NULL,--�Ƿ�ͨ�� 0��� 1ͨ��
	[IsHave] [int] NULL,--�Ƿ���Ƹ����Ա�� 0û�� 1�е���
	[Remark] [nvarchar](1000) NULL,--��ע
	[SubTime] [datetime] NULL,--����ʱ��	
 CONSTRAINT [PK_RecruitInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RecruitInfos] ADD  CONSTRAINT [DF_RecruitInfos_IsHave]  DEFAULT ((0)) FOR [IsHave]
GO




CREATE TABLE [dbo].[UserInfos](--Ա����
	[ID] [int] IDENTITY(1,1) NOT NULL,--������������Ա�����
	[UserName] [nvarchar](50) NULL,--����
	[Pwd] [nvarchar](100) NULL,--����
	[Gender] [nvarchar](50) NULL,--�Ա�
	[Mail] [nvarchar](50) NULL,--����
	[Birthday] [datetime] NULL,--����
	[Marriage] [string] NULL,--����״��
	[Political] [string] NULL,--������ò
	[Nation] [nvarchar](100) NULL,--����
	[Province] [nvarchar](50) NULL,--����
	[HomeAddress] [nvarchar](255) NULL,--סַ
	[IDNumber] [nvarchar](255) NULL,--���֤
	[Tel] [nvarchar](50) NULL,--�绰
	[College] [nvarchar](255) NULL,--��ҵԺУ
	[Speciality] [nvarchar](255) NULL,--רҵ
	[KultuLevel] [nvarchar](100) NULL,--ѧ��
	[Salary] [int] NULL,--����
	[Department] [int] NULL,--����
	[Job] [int] NULL,--ְλ
	[Educational] [nvarchar](50) NULL,--ѧ��
	[EntryTime] [datetime] NULL,--��ְʱ��
	[FileName] [nvarchar](255) NULL,--��ͬ����
	[FilePath] [nvarchar](255) NULL,--��ͬ·��
	[SubTime] [datetime] NULL,--���ʱ��
 CONSTRAINT [PK_UserInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Pollan](--������ò��
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PoliticalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pollan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[EducationalSort](--ѧ����
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_EducationalSort] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[MaritalStatus](--����״����
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaritalName] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO