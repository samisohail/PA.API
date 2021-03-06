USE [master]
GO
/****** Object:  Database [PA24]    Script Date: 10/1/2018 11:25:10 PM ******/
CREATE DATABASE [PA24]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PA24', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PA24.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PA24_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\PA24_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PA24] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PA24].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PA24] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PA24] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PA24] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PA24] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PA24] SET ARITHABORT OFF 
GO
ALTER DATABASE [PA24] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PA24] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PA24] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PA24] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PA24] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PA24] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PA24] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PA24] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PA24] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PA24] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PA24] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PA24] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PA24] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PA24] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PA24] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PA24] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PA24] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PA24] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PA24] SET  MULTI_USER 
GO
ALTER DATABASE [PA24] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PA24] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PA24] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PA24] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PA24]
GO
/****** Object:  Schema [Configuration]    Script Date: 10/1/2018 11:25:10 PM ******/
CREATE SCHEMA [Configuration]
GO
/****** Object:  Schema [Documents]    Script Date: 10/1/2018 11:25:10 PM ******/
CREATE SCHEMA [Documents]
GO
/****** Object:  Schema [Reference]    Script Date: 10/1/2018 11:25:10 PM ******/
CREATE SCHEMA [Reference]
GO
/****** Object:  Schema [Security]    Script Date: 10/1/2018 11:25:10 PM ******/
CREATE SCHEMA [Security]
GO
/****** Object:  Table [Configuration].[ConfigurationTypes]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Configuration].[ConfigurationTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_ConfigTypes_Active]  DEFAULT ((1)),
 CONSTRAINT [PK_ConfigTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Configuration].[OrgConfigurations]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuration].[OrgConfigurations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ConfigurationId] [bigint] NOT NULL,
	[OrganizationId] [bigint] NOT NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [bigint] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifyReason] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_OrgConfigurations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AlertTypes]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlertTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_AlertTypes_Active]  DEFAULT ((1)),
 CONSTRAINT [PK_AlertTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParentTasks]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentTasks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TaskId] [bigint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_T_ParentTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[OrgID] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[ProjectManager] [uniqueidentifier] NULL,
	[Budget] [numeric](18, 3) NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifyReason] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectTasks]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectTasks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[ProjectId] [bigint] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[TaskOwnerId] [bigint] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[AssignedToUserId] [bigint] NULL,
	[StatusId] [int] NOT NULL,
	[CompletedDate] [datetime] NULL,
	[NeedApproval] [bit] NOT NULL,
	[ApproverId] [bigint] NULL,
	[AppovalStatusId] [int] NULL,
	[AppovalStatusDate] [datetime] NULL,
	[EstimatedHours] [numeric](18, 2) NOT NULL,
	[ActualHours] [numeric](18, 2) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[AlertTypeId] [int] NULL,
 CONSTRAINT [PK_T_ProjectTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectTeamMembers]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectTeamMembers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectId] [bigint] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[MemberAcceptedReq] [bit] NOT NULL,
	[MemberResponseDate] [datetime] NULL,
	[MemberResponseComments] [nvarchar](max) NULL,
	[RoleInProject] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProjectTeamMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TasksChat]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TasksChat](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[MessageFrom] [uniqueidentifier] NOT NULL,
	[MessageTo] [uniqueidentifier] NULL,
	[ProjectId] [bigint] NULL,
	[TaskId] [bigint] NULL,
	[IsRead] [bit] NOT NULL,
	[ReadOn] [datetime] NULL,
	[ParentMessageId] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_TasksChat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Documents].[DocumentCategories]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Documents].[DocumentCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_DocCategories_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Documents].[DocumentsDetails]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Documents].[DocumentsDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](150) NULL,
	[DocumentName] [nvarchar](150) NOT NULL,
	[ContentType] [nvarchar](150) NOT NULL,
	[ContentLength] [bigint] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[DeletedOn] [datetime] NULL,
	[DeleteReason] [nvarchar](500) NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Active] [bit] NOT NULL,
	[DocumentCategoryId] [int] NULL,
 CONSTRAINT [PK_Documents.DocumentsDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Documents].[DocumentsStore]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Documents].[DocumentsStore](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueId] [uniqueidentifier] NOT NULL,
	[Document] [varbinary](max) NOT NULL,
	[DocumentId] [bigint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_DocumentsStore] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Reference].[ProjectTypes]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Reference].[ProjectTypes](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](199) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[OrgId] [uniqueidentifier] NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTo] [datetime] NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_T_ProjectType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Reference].[Status]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Reference].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EffectiveFrom] [datetime] NULL,
	[EffectiveTo] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_T_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Security].[Organisations]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Security].[Organisations](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Address] [nvarchar](200) NOT NULL,
	[ContactEmail] [nvarchar](200) NOT NULL,
	[ContactPhone] [nvarchar](20) NULL,
	[CreatedOn] [datetime] NULL DEFAULT (getdate()),
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
	[LastActivityType] [char](1) NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Security].[Roles]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Security].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [bigint] NOT NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_Security_Roles_CreatedOn]  DEFAULT (getdate()),
	[ModifiedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[LastActivity] [char](1) NOT NULL CONSTRAINT [DF_Security_Roles_LastActivity]  DEFAULT ('I'),
	[Comments] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_Security_Roles_Active]  DEFAULT ((1)),
	[OrgId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Security].[UserRoles]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[UserRoles](
	[Id] [bigint] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[Active] [bit] NOT NULL DEFAULT ((1)),
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Security].[Users]    Script Date: 10/1/2018 11:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Security].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DOB] [datetime] NOT NULL,
	[BusinessName] [nvarchar](max) NULL,
	[OrgId] [uniqueidentifier] NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CityId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
	[UAN] [nvarchar](max) NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[DeletedOn] [datetime] NULL,
	[BlockedOn] [datetime] NULL,
	[Reason] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordSalt] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Security.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [Configuration].[ConfigurationTypes] ON 

INSERT [Configuration].[ConfigurationTypes] ([Id], [Name], [Active]) VALUES (1, N'Employee review required on project close', 1)
INSERT [Configuration].[ConfigurationTypes] ([Id], [Name], [Active]) VALUES (2, N'Enable tasks hours loggin', 1)
INSERT [Configuration].[ConfigurationTypes] ([Id], [Name], [Active]) VALUES (3, N'Enable Gantt Chart', 1)
SET IDENTITY_INSERT [Configuration].[ConfigurationTypes] OFF
SET IDENTITY_INSERT [dbo].[AlertTypes] ON 

INSERT [dbo].[AlertTypes] ([Id], [Name], [Active]) VALUES (1, N'Normal', 1)
SET IDENTITY_INSERT [dbo].[AlertTypes] OFF
INSERT [Security].[Organisations] ([Id], [Name], [Description], [Address], [ContactEmail], [ContactPhone], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [LastActivityType], [Comments], [Active]) VALUES (N'ce4b1dbc-d92a-4f04-bc1c-96135a05e623', N'KPMG', N'KPMG', N'George Street Sydney', N'kpmg@kpmg.com', N'444874989', CAST(N'2018-09-30 15:43:46.107' AS DateTime), 1, NULL, NULL, N'I', NULL, 1)
INSERT [Security].[Roles] ([Id], [Name], [Description], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn], [LastActivity], [Comments], [Active], [OrgId]) VALUES (N'51240c65-e865-426f-94f5-891a835a265d', N'Admin', N'Admin', 1, CAST(N'2018-09-30 15:49:02.420' AS DateTime), NULL, NULL, N'I', NULL, 1, N'ce4b1dbc-d92a-4f04-bc1c-96135a05e623')
INSERT [Security].[UserRoles] ([Id], [UserId], [RoleId], [Active]) VALUES (1, N'8f676e6b-a275-4ed9-af47-a42f2ba074b3', N'51240c65-e865-426f-94f5-891a835a265d', 1)
INSERT [Security].[Users] ([Id], [FirstName], [LastName], [DOB], [BusinessName], [OrgId], [Gender], [Address], [CityId], [CountryId], [UAN], [CreatedBy], [CreatedOn], [DeletedOn], [BlockedOn], [Reason], [Comments], [Email], [EmailConfirmed], [PasswordSalt], [Password], [Phone], [PhoneNumberConfirmed], [TwoFactorEnabled], [AccessFailedCount], [Active]) VALUES (N'8f676e6b-a275-4ed9-af47-a42f2ba074b3', N'Rizwan', N'Ahmed', CAST(N'2018-09-30 15:23:46.007' AS DateTime), N'', N'ce4b1dbc-d92a-4f04-bc1c-96135a05e623', N'm', N'wiley park sydney', 1, 1, NULL, N'517df653-cc41-4326-becf-48c89554df8a', CAST(N'2018-09-30 15:23:45.993' AS DateTime), NULL, NULL, NULL, N'', N'admin@kpmg.com', 1, N'', N'123456', N'324234', 0, 0, 0, 1)
ALTER TABLE [Configuration].[OrgConfigurations] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [Configuration].[OrgConfigurations] ADD  CONSTRAINT [DF_OrgConfiguration_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ParentTasks] ADD  CONSTRAINT [DF_T_ParentTasks_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_StatusId]  DEFAULT ((1)) FOR [StatusId]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_Table_1_NeedReview]  DEFAULT ((0)) FOR [NeedApproval]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_EstimatedHours]  DEFAULT ((0)) FOR [EstimatedHours]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_ActualHours]  DEFAULT ((0)) FOR [ActualHours]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_LastActivityType]  DEFAULT ('I') FOR [LastActivityType]
GO
ALTER TABLE [dbo].[ProjectTasks] ADD  CONSTRAINT [DF_T_ProjectTasks_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ProjectTeamMembers] ADD  CONSTRAINT [DF_ProjectTeamMembers_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[ProjectTeamMembers] ADD  CONSTRAINT [DF_ProjectTeamMembers_LastActivityType]  DEFAULT ('I') FOR [LastActivityType]
GO
ALTER TABLE [dbo].[ProjectTeamMembers] ADD  CONSTRAINT [DF_ProjectTeamMembers_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ProjectTeamMembers] ADD  CONSTRAINT [DF_ProjectTeamMembers_MemberAcceptedReq]  DEFAULT ((0)) FOR [MemberAcceptedReq]
GO
ALTER TABLE [dbo].[TasksChat] ADD  CONSTRAINT [DF_TasksChat_IsRead]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[TasksChat] ADD  CONSTRAINT [DF_TasksChat_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TasksChat] ADD  CONSTRAINT [DF_TasksChat_LastActivityType]  DEFAULT ('I') FOR [LastActivityType]
GO
ALTER TABLE [dbo].[TasksChat] ADD  CONSTRAINT [DF_TasksChat_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Documents].[DocumentCategories] ADD  CONSTRAINT [DF_Ref_DocCategories_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [Documents].[DocumentCategories] ADD  CONSTRAINT [DF_Ref_DocCategories_Isactive]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Documents].[DocumentsDetails] ADD  CONSTRAINT [DF_Documents.DocumentsDetails_ContentLength]  DEFAULT ((0)) FOR [ContentLength]
GO
ALTER TABLE [Documents].[DocumentsDetails] ADD  CONSTRAINT [DF_Documents_Details_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [Documents].[DocumentsDetails] ADD  CONSTRAINT [DF_Documents.DocumentsDetails_LastActivityType]  DEFAULT ('I') FOR [LastActivityType]
GO
ALTER TABLE [Documents].[DocumentsDetails] ADD  CONSTRAINT [DF_Documents.DocumentsDetails_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Documents].[DocumentsStore] ADD  CONSTRAINT [DF_DocumentsStore_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Reference].[ProjectTypes] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [Reference].[ProjectTypes] ADD  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [Reference].[Status] ADD  CONSTRAINT [DF_T_Status_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [Reference].[Status] ADD  CONSTRAINT [DF_T_Status_LastActivityType]  DEFAULT ('I') FOR [LastActivityType]
GO
ALTER TABLE [Reference].[Status] ADD  CONSTRAINT [DF_T_Status_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[ParentTasks]  WITH CHECK ADD  CONSTRAINT [FK_ParentTasks_ProjectTasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[ProjectTasks] ([Id])
GO
ALTER TABLE [dbo].[ParentTasks] CHECK CONSTRAINT [FK_ParentTasks_ProjectTasks]
GO
ALTER TABLE [dbo].[TasksChat]  WITH CHECK ADD  CONSTRAINT [FK_TasksChat_ProjectTasks] FOREIGN KEY([TaskId])
REFERENCES [dbo].[ProjectTasks] ([Id])
GO
ALTER TABLE [dbo].[TasksChat] CHECK CONSTRAINT [FK_TasksChat_ProjectTasks]
GO
ALTER TABLE [Documents].[DocumentsStore]  WITH CHECK ADD  CONSTRAINT [FK_DocumentsStore_DocumentsDetails] FOREIGN KEY([DocumentId])
REFERENCES [Documents].[DocumentsDetails] ([Id])
GO
ALTER TABLE [Documents].[DocumentsStore] CHECK CONSTRAINT [FK_DocumentsStore_DocumentsDetails]
GO
ALTER TABLE [Security].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [Security].[Roles] ([Id])
GO
ALTER TABLE [Security].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [Security].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [Security].[Users] ([Id])
GO
ALTER TABLE [Security].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'when approval status was changed ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProjectTasks', @level2type=N'COLUMN',@level2name=N'AppovalStatusDate'
GO
USE [master]
GO
ALTER DATABASE [PA24] SET  READ_WRITE 
GO
