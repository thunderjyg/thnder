USE [AppDB]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member](
	[Member_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Member_Member_ID]  DEFAULT (newid()),
	[Member_Num] [varchar](50) NULL,
	[Member_Name] [varchar](50) NULL,
	[Member_Phone] [int] NULL,
	[Member_Sex] [varchar](50) NULL,
	[Member_Birthday] [datetime] NULL,
	[Member_Photo] [varchar](200) NULL,
	[Member_UserID] [uniqueidentifier] NULL,
	[Member_Introduce] [text] NULL,
	[Member_FilePath] [varchar](200) NULL,
	[Member_CreateTime] [datetime] NULL CONSTRAINT [DF_Member_Member_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Member_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Function]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Function](
	[Function_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_Function_Function_ID]  DEFAULT (newid()),
	[Function_Num] [varchar](50) NULL,
	[Function_Name] [varchar](50) NULL,
	[Function_ByName] [varchar](50) NULL,
	[Function_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_Function_Function_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_Function] PRIMARY KEY CLUSTERED 
(
	[Function_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Menu]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Menu](
	[Menu_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_Menu_Menu_ID]  DEFAULT (newid()),
	[Menu_Num] [varchar](50) NULL,
	[Menu_Name] [varchar](50) NULL,
	[Menu_Url] [varchar](50) NULL,
	[Menu_Icon] [varchar](50) NULL,
	[Menu_ParentID] [uniqueidentifier] NULL,
	[Menu_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_Menu_Menu_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_Menu] PRIMARY KEY CLUSTERED 
(
	[Menu_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_MenuFunction]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_MenuFunction](
	[MenuFunction_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_MenuFunction_MenuFunction_ID]  DEFAULT (newid()),
	[MenuFunction_MenuID] [uniqueidentifier] NULL,
	[MenuFunction_FunctionID] [uniqueidentifier] NULL,
	[MenuFunction_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_MenuFunction_MenuFunction_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_MenuFunction] PRIMARY KEY CLUSTERED 
(
	[MenuFunction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_Number]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Number](
	[Number_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_Number_Number_ID]  DEFAULT (newid()),
	[Number_Num] [varchar](50) NULL,
	[Number_DataBase] [varchar](50) NULL,
	[Number_TableName] [varchar](50) NULL,
	[Number_NumField] [varchar](50) NULL,
	[Number_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_Number_Number_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_Number] PRIMARY KEY CLUSTERED 
(
	[Number_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_Role]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_Role](
	[Role_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_Role_Role_ID]  DEFAULT (newid()),
	[Role_Num] [varchar](50) NULL,
	[Role_Name] [varchar](50) NULL,
	[Role_Remark] [varchar](500) NULL,
	[Role_IsDelete] [int] NULL,
	[Role_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_Role_Role_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_Role] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_RoleMenuFunction]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_RoleMenuFunction](
	[RoleMenuFunction_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_RoleMenuFunction_RoleMenuFunction_ID]  DEFAULT (newid()),
	[RoleMenuFunction_RoleID] [uniqueidentifier] NULL,
	[RoleMenuFunction_FunctionID] [uniqueidentifier] NULL,
	[RoleMenuFunction_MenuID] [uniqueidentifier] NULL,
	[RoleMenuFunction_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_RoleMenuFunction_RoleMenuFunction_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_RoleMenuFunction] PRIMARY KEY CLUSTERED 
(
	[RoleMenuFunction_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sys_User]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sys_User](
	[User_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_User_User_ID]  DEFAULT (newid()),
	[User_Name] [varchar](50) NULL,
	[User_LoginName] [varchar](50) NULL,
	[User_Pwd] [varchar](100) NULL,
	[User_Email] [varchar](50) NULL,
	[User_IsDelete] [int] NULL,
	[User_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_User_User_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sys_UserRole]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sys_UserRole](
	[UserRole_ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Sys_UserRole_UserRole_ID]  DEFAULT (newid()),
	[UserRole_UserID] [uniqueidentifier] NULL,
	[UserRole_RoleID] [uniqueidentifier] NULL,
	[UserRole_CreateTime] [datetime] NULL CONSTRAINT [DF_Sys_UserRole_UserRole_CreateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_Sys_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRole_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Member] ([Member_ID], [Member_Num], [Member_Name], [Member_Phone], [Member_Sex], [Member_Birthday], [Member_Photo], [Member_UserID], [Member_Introduce], [Member_FilePath], [Member_CreateTime]) VALUES (N'9a604aa2-9ae6-4a2f-8ddb-d9e0289ead9e', N'1', N'测试会员', 131231, N'男', CAST(N'2018-04-25 00:00:00.000' AS DateTime), N'/Content/UpFile/89da9231-427c-47a6-8f68-642caa134b43.jpg', N'a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', N'<p>1231231<img src="/Resource/Admin/lib/neditor/net/upload/image/20180629/6366588141156673624264764.png" alt="login2.png"/><img src="/Admin/lib/nUeditor/upload/image/20180704/6366629778310116875946386.png" alt="1242080_hao-zhi-ying.png"/></p>', N'/Content/UpFile/fc0ef283-b8c1-4fcf-851c-51141a2be661.txt', CAST(N'2018-04-25 23:00:06.637' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'b6fd5425-504a-46a9-993b-2f8dc9158eb8', N'80', N'打印', N'Print', CAST(N'2016-06-20 13:40:36.787' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'c9518758-b2e1-4f51-b517-5282e273889c', N'10', N'能否拥有该菜单', N'Have', CAST(N'2016-06-20 13:40:29.657' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'f27ecb0a-197d-47b1-b243-59a8c71302bf', N'60', N'检索', N'Search', CAST(N'2017-02-16 17:06:23.430' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'383e7ee2-7690-46ac-9230-65155c84aa30', N'50', N'保存', N'Save', CAST(N'2017-04-22 13:51:52.837' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'9c388461-2704-4c5e-a729-72c17e9018e1', N'40', N'删除', N'Delete', CAST(N'2016-06-20 13:40:52.360' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', N'20', N'添加', N'Add', CAST(N'2016-06-20 13:40:36.787' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'2401f4d0-60b0-4e2e-903f-84c603373572', N'70', N'导出', N'GetExcel', CAST(N'2017-02-09 16:34:14.017' AS DateTime))
INSERT [dbo].[Sys_Function] ([Function_ID], [Function_Num], [Function_Name], [Function_ByName], [Function_CreateTime]) VALUES (N'e7ef2a05-8317-41c3-b588-99519fe88bf9', N'30', N'修改', N'Edit', CAST(N'2016-06-20 13:40:43.153' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'4ce21a81-1cae-44d2-b29e-07058ff04b3e', N'Z-160', N'代码创建', N'/Admin/CreateCode/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:17:32.723' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'e5d4da6b-aab0-4aaa-982f-43673e8152c0', N'Z-130', N'菜单功能', N'/Admin/MenuFunction/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:18:33.997' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'd721fc55-2174-40eb-bb37-5c54a158525a', N'Z-120', N'功能管理', N'/Admin/Function/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:18:21.087' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'9591f249-1471-44f7-86b5-6fdae8b93888', N'Z', N'系统管理', NULL, N'fa fa-desktop', NULL, CAST(N'2018-03-10 12:16:38.890' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'Z-100', N'用户管理', N'/Admin/User/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:18:03.657' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'bd024f3a-99a7-4407-861c-a016f243f222', N'Z-140', N'角色功能', N'/Admin/RoleFunction/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:18:46.617' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'A-100', N'会员管理', N'/Admin/Member/Index?id=1', NULL, N'1ec76c4c-b9b3-4517-9854-f08cd11d653d', CAST(N'2018-04-25 21:36:28.533' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'60ae9382-31ab-4276-a379-d3876e9bb783', N'Z-110', N'角色管理', N'/Admin/Role/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:18:55.290' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'f35d64ae-ecb7-4d06-acfb-d91595966d9e', N'Z-150', N'修改密码', N'/Admin/ChangePwd/Index', NULL, N'9591f249-1471-44f7-86b5-6fdae8b93888', CAST(N'2018-03-10 12:17:03.810' AS DateTime))
INSERT [dbo].[Sys_Menu] ([Menu_ID], [Menu_Num], [Menu_Name], [Menu_Url], [Menu_Icon], [Menu_ParentID], [Menu_CreateTime]) VALUES (N'1ec76c4c-b9b3-4517-9854-f08cd11d653d', N'A', N'基础信息', NULL, N'fa fa-cubes', NULL, CAST(N'2018-04-25 21:18:09.403' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'58d55c9f-eb0b-4e37-8729-018ba15add24', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'2401f4d0-60b0-4e2e-903f-84c603373572', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'c52908ae-68a7-447d-862a-1691e9191f46', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'9c388461-2704-4c5e-a729-72c17e9018e1', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'f7f796cd-7eef-44e5-8b72-16bbb103513d', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'2401f4d0-60b0-4e2e-903f-84c603373572', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'cbb4517a-d0a8-4c9e-a59f-18d6b88a5457', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'e7ef2a05-8317-41c3-b588-99519fe88bf9', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'a49b958c-f00c-4c0d-b031-21190e5c74fa', N'f35d64ae-ecb7-4d06-acfb-d91595966d9e', N'c9518758-b2e1-4f51-b517-5282e273889c', CAST(N'2018-04-22 15:47:38.933' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'9c195f15-166f-41b6-969c-3fc1a7b16126', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'9c388461-2704-4c5e-a729-72c17e9018e1', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'5851d23f-7de2-48b1-8340-4feef46b8a76', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'9c388461-2704-4c5e-a729-72c17e9018e1', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'f933b4df-e994-4366-916a-55610dab5d5e', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'383e7ee2-7690-46ac-9230-65155c84aa30', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'02061825-c0bd-4fa4-a2ea-57f57602c243', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'5fa5c451-d682-459d-a148-5b9753e976d3', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'f27ecb0a-197d-47b1-b243-59a8c71302bf', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'ceaf3543-525d-4b42-a6ff-64c9e602198e', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'f27ecb0a-197d-47b1-b243-59a8c71302bf', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'45a6399c-5b26-4a47-9957-8ac8cb0c1ff7', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'779246d1-84ce-4daf-9a49-8fa4abb31404', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'383e7ee2-7690-46ac-9230-65155c84aa30', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'7baab27f-74cc-4eb3-9d04-9e72f0cc8a94', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'e7ef2a05-8317-41c3-b588-99519fe88bf9', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'bb14769d-4760-4341-9faf-9fa82eeada65', N'2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', N'e7ef2a05-8317-41c3-b588-99519fe88bf9', CAST(N'2018-06-28 11:30:09.723' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'7861b618-0b12-4a56-abda-a5e8d17ac5d7', N'2ff9bb67-aa42-48cf-80c9-6d1cfb6b1ead', N'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', CAST(N'2018-06-28 11:30:09.723' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'177ce01f-add8-4fd5-a2a6-a652803b0f38', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'bffefb1c-8988-4ddf-b4ac-81c2b30e80cd', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'16cee2be-61db-4129-ba17-ad9f87167d37', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'e7ef2a05-8317-41c3-b588-99519fe88bf9', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'ed266ed2-b722-4ecb-80d2-aee8ce94686a', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'2401f4d0-60b0-4e2e-903f-84c603373572', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'aaa679ce-d68c-4563-b485-b5af5e3cd9b9', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'f27ecb0a-197d-47b1-b243-59a8c71302bf', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'f01a4a07-89fd-4324-bc72-c2fe144b7974', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'383e7ee2-7690-46ac-9230-65155c84aa30', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'0962a398-d4a5-455e-8d2f-c7c6b41fc9cf', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', N'c9518758-b2e1-4f51-b517-5282e273889c', CAST(N'2018-04-22 15:46:46.540' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'259c0396-8390-4632-be02-d02dc1c17123', N'bd024f3a-99a7-4407-861c-a016f243f222', N'c9518758-b2e1-4f51-b517-5282e273889c', CAST(N'2018-07-31 13:51:51.553' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'b9776939-9f52-4938-be8a-e4b57d2503bf', N'60ae9382-31ab-4276-a379-d3876e9bb783', N'c9518758-b2e1-4f51-b517-5282e273889c', CAST(N'2018-04-22 15:46:57.700' AS DateTime))
INSERT [dbo].[Sys_MenuFunction] ([MenuFunction_ID], [MenuFunction_MenuID], [MenuFunction_FunctionID], [MenuFunction_CreateTime]) VALUES (N'a70da34c-b1e6-48cf-a2de-f8d5b7b21324', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', N'c9518758-b2e1-4f51-b517-5282e273889c', CAST(N'2018-06-28 16:58:22.413' AS DateTime))
INSERT [dbo].[Sys_Number] ([Number_ID], [Number_Num], [Number_DataBase], [Number_TableName], [Number_NumField], [Number_CreateTime]) VALUES (N'b5fcc999-85b9-4dce-a3fc-64b43ef82f68', N'1', NULL, N'Member', N'Member_Num', CAST(N'2018-04-25 23:00:03.723' AS DateTime))
INSERT [dbo].[Sys_Role] ([Role_ID], [Role_Num], [Role_Name], [Role_Remark], [Role_IsDelete], [Role_CreateTime]) VALUES (N'18fa4771-6f58-46a3-80d2-6f0f5e9972e3', N'0001', N'超级管理员', N'拥有所有权限', 2, CAST(N'2016-06-20 10:20:10.073' AS DateTime))
INSERT [dbo].[Sys_Role] ([Role_ID], [Role_Num], [Role_Name], [Role_Remark], [Role_IsDelete], [Role_CreateTime]) VALUES (N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'0002', N'普通用户', NULL, 1, CAST(N'2016-07-06 17:59:20.527' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'a3979835-1be7-4c57-888c-0c1d2d7f47bb', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'f27ecb0a-197d-47b1-b243-59a8c71302bf', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', CAST(N'2018-06-15 18:44:10.837' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'9e747fd5-a9ab-4b54-8ce7-4a7c565a2a9c', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'c9518758-b2e1-4f51-b517-5282e273889c', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', CAST(N'2018-06-15 18:44:10.813' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'25945f65-b9fb-42d9-b6f8-82e43467ca58', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'c9518758-b2e1-4f51-b517-5282e273889c', N'f35d64ae-ecb7-4d06-acfb-d91595966d9e', CAST(N'2018-06-15 18:44:10.807' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'72865097-bc7b-4385-b7e8-920f9d4306ce', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'c9518758-b2e1-4f51-b517-5282e273889c', N'7c34c2fd-98ed-4655-aa04-bb00b915a751', CAST(N'2018-06-15 18:44:10.843' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'860d2eb8-a2b1-4bb5-876b-be31f0d8eda1', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'383e7ee2-7690-46ac-9230-65155c84aa30', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', CAST(N'2018-06-15 18:44:10.830' AS DateTime))
INSERT [dbo].[Sys_RoleMenuFunction] ([RoleMenuFunction_ID], [RoleMenuFunction_RoleID], [RoleMenuFunction_FunctionID], [RoleMenuFunction_MenuID], [RoleMenuFunction_CreateTime]) VALUES (N'636b2efd-d85e-45f9-92a6-cba30e3e44e6', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', N'e7ef2a05-8317-41c3-b588-99519fe88bf9', N'38d864ff-f6e7-43af-8c5c-8bbcf9fa586d', CAST(N'2018-06-15 18:44:10.820' AS DateTime))
INSERT [dbo].[Sys_User] ([User_ID], [User_Name], [User_LoginName], [User_Pwd], [User_Email], [User_IsDelete], [User_CreateTime]) VALUES (N'0198459e-2034-4533-b843-5d227ad20740', N'管理员', N'admin', N'123', N'1396510655@qq.com', 2, CAST(N'2017-04-06 19:55:53.083' AS DateTime))
INSERT [dbo].[Sys_User] ([User_ID], [User_Name], [User_LoginName], [User_Pwd], [User_Email], [User_IsDelete], [User_CreateTime]) VALUES (N'a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', N'普通用户', N'user', N'123', NULL, 1, CAST(N'2018-03-10 12:21:15.160' AS DateTime))
INSERT [dbo].[Sys_UserRole] ([UserRole_ID], [UserRole_UserID], [UserRole_RoleID], [UserRole_CreateTime]) VALUES (N'3a20ab84-cb46-47b9-a1de-34cf14b71c6f', N'0198459e-2034-4533-b843-5d227ad20740', N'18fa4771-6f58-46a3-80d2-6f0f5e9972e3', CAST(N'2018-07-04 17:59:31.383' AS DateTime))
INSERT [dbo].[Sys_UserRole] ([UserRole_ID], [UserRole_UserID], [UserRole_RoleID], [UserRole_CreateTime]) VALUES (N'a3ddf66d-49ff-4981-8090-9caa326e13f9', N'a7eae7ab-0de4-4026-8da9-6529f8a1c3e2', N'40ff1844-c099-4061-98e0-cd6e544fcfd3', CAST(N'2018-04-25 20:51:36.350' AS DateTime))
/****** Object:  StoredProcedure [dbo].[GetNumber]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNumber]
	@numfield varchar(50),--varchar(8000),         --字段名
    @tablename varchar(50)              --表名
AS
BEGIN
	DECLARE @Number int = 0
	select @Number=Number_Num from Sys_Number where Number_TableName=@tablename and Number_NumField=@numfield
    IF @Number=0 BEGIN
		insert into Sys_Number(Number_TableName,Number_NumField,Number_Num) values(@tablename,@numfield,1)
		select 1
	END
	ELSE BEGIN
		update Sys_Number set Number_Num = @Number +1 where Number_TableName=@tablename and Number_NumField=@numfield
		select (@Number +1)
	END
END





GO
/****** Object:  StoredProcedure [dbo].[PROC_SPLITPAGE]    Script Date: 2018/8/1 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------系统的--------------
CREATE  PROCEDURE [dbo].[PROC_SPLITPAGE]
    @SQL text,--varchar(8000),         --要执行的SQL语句
    @PAGE INT = 1,              --要显示的页码
    @PAGESIZE INT,              --每页的大小
    @PAGECOUNT INT = 0 OUT,     --总页数
    @RECORDCOUNT INT = 0 OUT    --总记录数
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @P1 INT

    EXEC SP_CURSOROPEN @P1 OUTPUT, @SQL, @SCROLLOPT = 1, @CCOPT = 1, @ROWCOUNT = @PAGECOUNT OUTPUT

    SET @RECORDCOUNT = @PAGECOUNT

    SELECT @PAGECOUNT=
        CEILING(1.0 * @PAGECOUNT / @PAGESIZE) , @PAGE = (@PAGE-1) * @PAGESIZE + 1

    EXEC SP_CURSORFETCH @P1, 16, @PAGE, @PAGESIZE 

    EXEC SP_CURSORCLOSE @P1
END





GO
