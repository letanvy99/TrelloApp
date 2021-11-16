USE [Trello]
GO
/****** Object:  Table [dbo].[CardLabels]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardLabels](
	[CardId] [int] NOT NULL,
	[LabelId] [int] NOT NULL,
 CONSTRAINT [PK_CardLabels] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC,
	[LabelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ListId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[SortOrder] [int] NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[Priority] [nvarchar](100) NULL,
	[DueDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CardUsers]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardUsers](
	[CardId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_CardUsers] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckLists]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardId] [int] NULL,
	[Name] [nvarchar](200) NULL,
	[SortOrder] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_CheckLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CheckListId] [int] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsCompleted] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labels]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkspaceId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Color] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lists]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkspaceId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Color] [nvarchar](50) NULL,
	[SortOrder] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Lists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](255) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[Birthday] [datetime2](0) NULL,
	[Gender] [nvarchar](10) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workspaces]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workspaces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Workspaces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkspaceUsers]    Script Date: 11/17/2021 12:15:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkspaceUsers](
	[UserId] [int] NOT NULL,
	[WorkspaceId] [int] NOT NULL,
 CONSTRAINT [PK_WorkspaceUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[WorkspaceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CardLabels] ([CardId], [LabelId]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[Cards] ON 

INSERT [dbo].[Cards] ([Id], [ListId], [Name], [SortOrder], [ImageUrl], [Priority], [DueDate], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 2, N'Bai Tap', 1, N'string', N'Trung Bình', CAST(N'2021-11-15T00:00:00.0000000' AS DateTime2), 0, CAST(N'2021-11-16T16:34:17.8687802' AS DateTime2), 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
INSERT [dbo].[CardUsers] ([CardId], [UserId]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[CheckLists] ON 

INSERT [dbo].[CheckLists] ([Id], [CardId], [Name], [SortOrder], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'check', 1, 0, CAST(N'2021-11-16T16:35:16.2276770' AS DateTime2), 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[CheckLists] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [CheckListId], [Name], [IsCompleted], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'123', 0, 0, CAST(N'2021-11-16T16:42:06.3271219' AS DateTime2), 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
SET IDENTITY_INSERT [dbo].[Labels] ON 

INSERT [dbo].[Labels] ([Id], [WorkspaceId], [Name], [Color], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, NULL, N'#FF6369', 0, CAST(N'2021-11-16T10:12:46.4617764' AS DateTime2), 0, 0, NULL)
INSERT [dbo].[Labels] ([Id], [WorkspaceId], [Name], [Color], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (2, 1, NULL, N'#61C76D', 0, CAST(N'2021-11-16T10:12:46.4870835' AS DateTime2), 0, 0, NULL)
INSERT [dbo].[Labels] ([Id], [WorkspaceId], [Name], [Color], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (3, 1, NULL, N'#7AC5FA', 0, CAST(N'2021-11-16T10:12:46.4872726' AS DateTime2), 0, 0, NULL)
INSERT [dbo].[Labels] ([Id], [WorkspaceId], [Name], [Color], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (4, 1, NULL, N'#D1458D', 0, CAST(N'2021-11-16T10:12:46.4879379' AS DateTime2), 0, 0, NULL)
INSERT [dbo].[Labels] ([Id], [WorkspaceId], [Name], [Color], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (5, 1, NULL, N'#D18156', 0, CAST(N'2021-11-16T10:12:46.4880384' AS DateTime2), 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[Labels] OFF
GO
SET IDENTITY_INSERT [dbo].[Lists] ON 

INSERT [dbo].[Lists] ([Id], [WorkspaceId], [Name], [Color], [SortOrder], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, 1, N'Tấn Vỹ 11112', N'#000000', 1, 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 2, 0, CAST(N'2021-11-16T12:34:30.4304484' AS DateTime2))
INSERT [dbo].[Lists] ([Id], [WorkspaceId], [Name], [Color], [SortOrder], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (2, 1, N'Doing', N'#000000', 1, 0, CAST(N'2021-11-16T16:32:48.9309005' AS DateTime2), 2, 0, NULL)
INSERT [dbo].[Lists] ([Id], [WorkspaceId], [Name], [Color], [SortOrder], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (3, 1, N'test List', N'#0000000', 2, 0, CAST(N'2021-11-16T17:02:32.1586134' AS DateTime2), 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[Lists] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [IsDeleted]) VALUES (1, N'User', 0)
INSERT [dbo].[Roles] ([Id], [Name], [IsDeleted]) VALUES (2, N'Admin', 0)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Email], [PasswordHash], [FirstName], [LastName], [ImageUrl], [Birthday], [Gender], [IsDeleted]) VALUES (2, N'admin', N'user@example.com', N'AQAAAAEAACcQAAAAEG4wohJX3f/sIP9XGAMSUlbt++wlK52ZI60uQ6i8aJaB5SpHR+B2QcfPkZs2CEiYAw==', N'vy', N'le', NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Workspaces] ON 

INSERT [dbo].[Workspaces] ([Id], [Name], [Description], [ImageUrl], [IsDeleted], [CreatedDate], [CreatedBy], [UpdatedBy], [UpdatedDate]) VALUES (1, N'aaaa', N'aaaa', NULL, 0, CAST(N'2021-11-16T10:12:46.2983726' AS DateTime2), 2, 0, NULL)
SET IDENTITY_INSERT [dbo].[Workspaces] OFF
GO
INSERT [dbo].[WorkspaceUsers] ([UserId], [WorkspaceId]) VALUES (2, 1)
GO
ALTER TABLE [dbo].[Cards] ADD  CONSTRAINT [DF_Cards_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Cards] ADD  CONSTRAINT [DF_Cards_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CheckLists] ADD  CONSTRAINT [DF_CheckLists_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[CheckLists] ADD  CONSTRAINT [DF_CheckLists_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Labels] ADD  CONSTRAINT [DF_Labels_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Labels] ADD  CONSTRAINT [DF_Labels_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF_Lists_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Lists] ADD  CONSTRAINT [DF_Lists_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Workspaces] ADD  CONSTRAINT [DF_Workspaces_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Workspaces] ADD  CONSTRAINT [DF_Workspaces_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CardLabels]  WITH CHECK ADD  CONSTRAINT [FK_CardLabels_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[CardLabels] CHECK CONSTRAINT [FK_CardLabels_Cards]
GO
ALTER TABLE [dbo].[CardLabels]  WITH CHECK ADD  CONSTRAINT [FK_CardLabels_Labels] FOREIGN KEY([LabelId])
REFERENCES [dbo].[Labels] ([Id])
GO
ALTER TABLE [dbo].[CardLabels] CHECK CONSTRAINT [FK_CardLabels_Labels]
GO
ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_Cards_Lists] FOREIGN KEY([ListId])
REFERENCES [dbo].[Lists] ([Id])
GO
ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_Cards_Lists]
GO
ALTER TABLE [dbo].[CardUsers]  WITH CHECK ADD  CONSTRAINT [FK_CardUsers_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[CardUsers] CHECK CONSTRAINT [FK_CardUsers_Cards]
GO
ALTER TABLE [dbo].[CardUsers]  WITH CHECK ADD  CONSTRAINT [FK_CardUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[CardUsers] CHECK CONSTRAINT [FK_CardUsers_Users]
GO
ALTER TABLE [dbo].[CheckLists]  WITH CHECK ADD  CONSTRAINT [FK_CheckLists_Cards] FOREIGN KEY([CardId])
REFERENCES [dbo].[Cards] ([Id])
GO
ALTER TABLE [dbo].[CheckLists] CHECK CONSTRAINT [FK_CheckLists_Cards]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Cards] FOREIGN KEY([CheckListId])
REFERENCES [dbo].[CheckLists] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Cards]
GO
ALTER TABLE [dbo].[Labels]  WITH CHECK ADD  CONSTRAINT [FK_Labels_Workspaces] FOREIGN KEY([WorkspaceId])
REFERENCES [dbo].[Workspaces] ([Id])
GO
ALTER TABLE [dbo].[Labels] CHECK CONSTRAINT [FK_Labels_Workspaces]
GO
ALTER TABLE [dbo].[Lists]  WITH CHECK ADD  CONSTRAINT [FK_Lists_Workspaces] FOREIGN KEY([WorkspaceId])
REFERENCES [dbo].[Workspaces] ([Id])
GO
ALTER TABLE [dbo].[Lists] CHECK CONSTRAINT [FK_Lists_Workspaces]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users]
GO
ALTER TABLE [dbo].[WorkspaceUsers]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceUsers_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceUsers] CHECK CONSTRAINT [FK_WorkspaceUsers_Users]
GO
ALTER TABLE [dbo].[WorkspaceUsers]  WITH CHECK ADD  CONSTRAINT [FK_WorkspaceUsers_Workspaces] FOREIGN KEY([WorkspaceId])
REFERENCES [dbo].[Workspaces] ([Id])
GO
ALTER TABLE [dbo].[WorkspaceUsers] CHECK CONSTRAINT [FK_WorkspaceUsers_Workspaces]
GO
