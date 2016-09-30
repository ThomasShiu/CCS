CREATE TABLE [dbo].[CS_SYSMODULE] (
[Id] varchar(50) NOT NULL,
[Name] nvarchar(200) NOT NULL,
[EnglishName] varchar(200) NULL,
[ParentId] varchar(50) NULL,
[Url] varchar(200) NULL,
[Iconic] varchar(200) NULL,
[Sort] int NULL,
[Remark] nvarchar(4000) NULL,
[Enable] bit NOT NULL,
[CreatePerson] varchar(200) NULL,
[CreateTime] datetime NULL,
[IsLast] bit NOT NULL,
[Version] timestamp NULL,
CONSTRAINT [PK_CS_SysModule]
PRIMARY KEY CLUSTERED ([Id] ASC)
WITH ( PAD_INDEX = OFF,
FILLFACTOR = 100,
IGNORE_DUP_KEY = OFF,
STATISTICS_NORECOMPUTE = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON,
DATA_COMPRESSION = NONE )
 ON [PRIMARY],
CONSTRAINT [FK_CS_SysModule_SysModule]
FOREIGN KEY ([ParentId])
REFERENCES [CS_SYSMODULE] ( [Id] )
)
ON [PRIMARY];
GO
ALTER TABLE [dbo].[CS_SYSMODULE] SET (LOCK_ESCALATION = TABLE);
GO

GO
CREATE TABLE [dbo].[CS_SYSMODULEOPERATE](
    [Id] [varchar](200) NOT NULL,
    [Name] [nvarchar](200) NOT NULL,
    [KeyCode] [varchar](200) NOT NULL,
    [ModuleId] [varchar](50) NOT NULL,
    [IsValid] [bit] NOT NULL,
    [Sort] [int] NOT NULL,
 CONSTRAINT [PK_CS_SysModuleOperate] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[CS_SYSROLE](
    [Id] [varchar](50) NOT NULL,
    [Name] [nvarchar](200) NOT NULL,
    [Description] [nvarchar](4000) NOT NULL,
    [CreateTime] [datetime] NOT NULL,
    [CreatePerson] [varchar](200) NOT NULL,
 CONSTRAINT [PK_SysRole] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[CS_SYSUSER](
    [Id] [varchar](50) NOT NULL,
    [UserName] [varchar](200) NOT NULL,
    [Password] [varchar](200) NOT NULL,
    [TrueName] [nvarchar](200) NULL,
    [Card] [varchar](50) NULL,
    [MobileNumber] [varchar](200) NULL,
    [PhoneNumber] [varchar](200) NULL,
    [QQ] [varchar](50) NULL,
    [EmailAddress] [varchar](200) NULL,
    [OtherContact] [varchar](200) NULL,
    [Province] [varchar](200) NULL,
    [City] [nvarchar](200) NULL,
    [Village] [nvarchar](200) NULL,
    [Address] [nvarchar](200) NULL,
    [State] [bit] NULL,
    [CreateTime] [datetime] NULL,
    [CreatePerson] [varchar](200) NULL,
    [Sex] [nvarchar](10) NULL,
    [Birthday] [datetime] NULL,
    [JoinDate] [datetime] NULL,
    [Marital] [nvarchar](10) NULL,
    [Political] [nvarchar](50) NULL,
    [Nationality] [nvarchar](20) NULL,
    [Native] [nvarchar](20) NULL,
    [School] [nvarchar](50) NULL,
    [Professional] [nvarchar](100) NULL,
    [Degree] [nvarchar](20) NULL,
    [DepId] [nvarchar](50) NOT NULL,
    [PosId] [nvarchar](50) NOT NULL,
    [Expertise] [nvarchar](3000) NULL,
    [JobState] [nvarchar](20) NULL,
    [Photo] [varchar](200) NULL,
    [Attach] [varchar](200) NULL,
 CONSTRAINT [PK_CS_SysUser] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份證' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'MobileNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'婚姻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Marital'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'黨派' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Political'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Nationality'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'籍貫' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Native'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'畢業學校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'School'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'就讀專業' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Professional'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'學歷' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Degree'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部門' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'DepId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'職位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'PosId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'個人簡介' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Expertise'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在職狀況' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'JobState'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'照片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Photo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CS_SYSUSER', @level2type=N'COLUMN',@level2name=N'Attach'
GO


CREATE TABLE [dbo].[CS_SYSROLESYSUSER](
    [SysUserId] [varchar](50) NOT NULL,
    [SysRoleId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CS_SysRoleSysUser] PRIMARY KEY CLUSTERED 
(
    [SysUserId] ASC,
    [SysRoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[CS_SYSRIGHT](
    [Id] [varchar](200) NOT NULL,
    [ModuleId] [varchar](50) NOT NULL,
    [RoleId] [varchar](50) NOT NULL,
    [Rightflag] [bit] NOT NULL,
 CONSTRAINT [PK_CS_SysRight] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[CS_SYSRIGHTOPERATE](
    [Id] [varchar](200) NOT NULL,
    [RightId] [varchar](200) NOT NULL,
    [KeyCode] [varchar](200) NOT NULL,
    [IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_CS_SysRightOperate] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[CS_SYSMODULE]  WITH NOCHECK ADD  CONSTRAINT [FK_CS_SysModule_SysModule] FOREIGN KEY([ParentId])
REFERENCES [dbo].[CS_SYSMODULE] ([Id])
GO

ALTER TABLE [dbo].[CS_SYSMODULE] NOCHECK CONSTRAINT [FK_CS_SysModule_SysModule]
GO

ALTER TABLE [dbo].[CS_SYSMODULEOPERATE]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysModuleOperate_SysModule] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[CS_SYSMODULE] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSMODULEOPERATE] CHECK CONSTRAINT [FK_CS_SysModuleOperate_SysModule]
GO


ALTER TABLE [dbo].[CS_SYSROLESYSUSER]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysRoleSysUser_SysRole] FOREIGN KEY([SysRoleId])
REFERENCES [dbo].[CS_SYSROLE] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSROLESYSUSER] CHECK CONSTRAINT [FK_CS_SysRoleSysUser_SysRole]
GO

ALTER TABLE [dbo].[CS_SYSROLESYSUSER]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysRoleSysUser_SysUser] FOREIGN KEY([SysUserId])
REFERENCES [dbo].[CS_SYSUSER] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSROLESYSUSER] CHECK CONSTRAINT [FK_CS_SysRoleSysUser_SysUser]
GO

ALTER TABLE [dbo].[CS_SYSRIGHT]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysRight_SysModule] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[CS_SYSMODULE] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSRIGHT] CHECK CONSTRAINT [FK_CS_SysRight_SysModule]
GO

ALTER TABLE [dbo].[CS_SYSRIGHT]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysRight_SysRole] FOREIGN KEY([RoleId])
REFERENCES [dbo].[CS_SYSROLE] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSRIGHT] CHECK CONSTRAINT [FK_CS_SysRight_SysRole]
GO
ALTER TABLE [dbo].[CS_SYSRIGHTOPERATE]  WITH CHECK ADD  CONSTRAINT [FK_CS_SysRightOperate_SysRight] FOREIGN KEY([RightId])
REFERENCES [dbo].[CS_SYSRIGHT] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CS_SYSRIGHTOPERATE] CHECK CONSTRAINT [FK_CS_SysRightOperate_SysRight]
GO

INSERT INTO [CS_SYSUSER] ([Id],[UserName],[Password],[TrueName],[Card],[MobileNumber],[PhoneNumber],[QQ],[EmailAddress],[OtherContact],[Province],[City],[Village],[Address],[State],[CreateTime],[CreatePerson],[Sex],[Birthday],[JoinDate],[Marital],[Political],[Nationality],[Native],[School],[Professional],[Degree],[DepId],[PosId],[Expertise],[JobState],[Photo],[Attach]) 
values ('admin','admin','01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00','系統管理員',NULL,NULL,'0921123456','07-6937937','thomas6712@gmail.com','thomas6712@gmail.com','440000','440100','440101','小小村落',1,'2016/9/28','admin',N'男','1978/12/24','2016/9/28',N'已婚',N'台灣',N'台灣',N'高雄市',N'南台科大',N'資訊管理',N'碩士','20000','20001',N'勤勞向學,為人友善,樂於助人',N'在職',NULL,NULL)




INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'INV01', N'入庫管理', N'IMPORT', N'Inventory', NULL, NULL, 1, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'INV02', N'出庫管理', N'EXPORT', N'Inventory', NULL, NULL, 2, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'Inventory', N'倉庫管理', N'Inv Stock', N'0', NULL, NULL, 0, NULL, 1, N'B050502', NULL, 0)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'MDU01', N'模組維護', NULL, N'SysModule', N'SysModule/CSSysModule', NULL, 1, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'MDU02', N'模組操作維護', N'Module Option', N'SysModule', N'SysModule/CSSysModule/CreateOpt', NULL, 2, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'root', N'頂級菜單', N'root', N'0', NULL, NULL, 0, NULL, 0, NULL, NULL, 0)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'SAL01', N'訂單主檔', N'Order Master', N'Sales', N'Sales/SAL01', NULL, 1, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'SAL02', N'訂單明細', N'Oder Detail', N'Sales', N'Sales/SAL02', NULL, 2, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'Sales', N'訂單管理', N'Sales Order', N'0', N'', NULL, 1, NULL, 1, N'B050502', NULL, 0)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'SYS01', N'系統日誌', N'Sys Log', N'System', N'System/SYS01', NULL, 1, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'SYS02', N'系統錯誤', N'Sys Exception', N'System', N'System/SYS02', NULL, 1, NULL, 1, N'B050502', NULL, 1)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'SysModule', N'權限管理', N'Module Manage', N'0', NULL, NULL, 99, NULL, 1, N'B050502', NULL, 0)
INSERT INTO [dbo].[CS_SYSMODULE] ([Id], [Name], [EnglishName], [ParentId], [Url], [Iconic], [Sort], [Remark], [Enable], [CreatePerson], [CreateTime], [IsLast]) VALUES (N'System', N'系統管理', N'Sys Admin', N'0', NULL, NULL, 98, NULL, 1, N'B050502', NULL, 0)

INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'MDU01Create', N'創建', N'Create', N'MDU01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'MDU01Delete', N'刪除', N'Delete', N'MDU01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'MDU01Edit', N'編輯', N'Edit', N'MDU01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'MDU01Query', N'查詢', N'Query', N'MDU01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'MDU01Save', N'保存', N'Save', N'MDU01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Create', N'創建', N'Create', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Delete', N'刪除', N'Delete', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Details', N'詳細', N'Details', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Edit', N'編輯', N'Edit', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Export', N'匯出', N'Export', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Query', N'查詢', N'Query', N'SAL01', 1, 0)
INSERT INTO [dbo].[CS_SYSMODULEOPERATE] ([Id], [Name], [KeyCode], [ModuleId], [IsValid], [Sort]) VALUES (N'SAL01Save', N'保存', N'Save', N'SAL01', 1, 0)

INSERT INTO [dbo].[CS_SYSROLE] ([Id], [Name], [Description], [CreateTime], [CreatePerson]) VALUES (N'administrator', N'超級管理員', N'全部授權', N'2016-09-28 00:00:00', N'Administrator')
INSERT INTO [dbo].[CS_SYSROLE] ([Id], [Name], [Description], [CreateTime], [CreatePerson]) VALUES (N'poweruser', N'超級使用者', N'部分授權', N'2016-09-28 00:00:00', N'Administrator')


INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorMDU01', N'MDU01', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorMDU02', N'MDU02', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSAL01', N'SAL01', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSAL02', N'SAL02', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSales', N'Sales', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSYS01', N'SYS01', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSYS02', N'SYS02', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSysModule', N'SysModule', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'administratorSystem', N'System', N'administrator', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'poweruserSAL01', N'SAL01', N'poweruser', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'poweruserSAL02', N'SAL02', N'poweruser', 1)
INSERT INTO [dbo].[CS_SYSRIGHT] ([Id], [ModuleId], [RoleId], [Rightflag]) VALUES (N'poweruserSales', N'Sales', N'poweruser', 1)


INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Create', N'administratorMDU01', N'Create', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Delete', N'administratorMDU01', N'Delete', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Details', N'administratorMDU01', N'Details', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Edit', N'administratorMDU01', N'Edit', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Query', N'administratorMDU01', N'Query', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU01Save', N'administratorMDU01', N'Save', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU02Query', N'administratorMDU02', N'Query', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorMDU02Save', N'administratorMDU02', N'Save', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Create', N'administratorSAL01', N'Create', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Delete', N'administratorSAL01', N'Delete', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Details', N'administratorSAL01', N'Details', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Edit', N'administratorSAL01', N'Edit', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Export', N'administratorSAL01', N'Export', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Query', N'administratorSAL01', N'Query', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSAL01Save', N'administratorSAL01', N'Save', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSysModuleCreate', N'administratorSysModule', N'Create', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSysModuleDelete', N'administratorSysModule', N'Delete', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSysModuleDetails', N'administratorSysModule', N'Details', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'administratorSysModuleEdit', N'administratorSysModule', N'Edit', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Create', N'poweruserSAL01', N'Create', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Delete', N'poweruserSAL01', N'Delete', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Details', N'poweruserSAL01', N'Details', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Edit', N'poweruserSAL01', N'Edit', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Export', N'poweruserSAL01', N'Export', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Query', N'poweruserSAL01', N'Query', 1)
INSERT INTO [dbo].[CS_SYSRIGHTOPERATE] ([Id], [RightId], [KeyCode], [IsValid]) VALUES (N'poweruserSAL01Save', N'poweruserSAL01', N'Save', 1)


INSERT INTO [dbo].[CS_SYSROLESYSUSER] ([SysUserId], [SysRoleId]) VALUES (N'admin', N'administrator')
INSERT INTO [dbo].[CS_SYSROLESYSUSER] ([SysUserId], [SysRoleId]) VALUES (N'b050720', N'poweruser')

-- 超級使用者

INSERT INTO [dbo].[CS_SYSUSER] ([Id], [UserName], [Password], [TrueName], [Card], [MobileNumber], [PhoneNumber], [QQ], [EmailAddress], [OtherContact], [Province], [City], [Village], [Address], [State], [CreateTime], [CreatePerson], [Sex], [Birthday], [JoinDate], [Marital], [Political], [Nationality], [Native], [School], [Professional], [Degree], [DepId], [PosId], [Expertise], [JobState], [Photo], [Attach]) VALUES (N'admin', N'admin', N'01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00', N'系統管理員', NULL, NULL, N'0921123456', N'07-6937937', N'thomas6712@gmail.com', N'thomas6712@gmail.com', N'440000', N'440100', N'440101', N'小小村落', 1, N'2016-09-28 00:00:00', N'admin', N'男', N'1978-12-24 00:00:00', N'2016-09-28 00:00:00', N'已婚', N'台灣', N'台灣', N'高雄市', N'南台科大', N'資訊管理', N'碩士', N'20000', N'20001', N'勤勞向學,為人友善,樂於助人', N'在職', NULL, NULL)
INSERT INTO [dbo].[CS_SYSUSER] ([Id], [UserName], [Password], [TrueName], [Card], [MobileNumber], [PhoneNumber], [QQ], [EmailAddress], [OtherContact], [Province], [City], [Village], [Address], [State], [CreateTime], [CreatePerson], [Sex], [Birthday], [JoinDate], [Marital], [Political], [Nationality], [Native], [School], [Professional], [Degree], [DepId], [PosId], [Expertise], [JobState], [Photo], [Attach]) VALUES (N'b050720', N'b050720', N'01-92-02-3A-7B-BD-73-25-05-16-F0-69-DF-18-B5-00', N'鄭捷羽', NULL, NULL, N'', N'07-6937937', N'', N'', N'440000', N'440100', N'440101', N'', 1, N'1900-01-01 00:00:00', N'admin', N'女', N'1978-12-24 00:00:00', N'2016-09-28 00:00:00', N'已婚', N'台灣', N'台灣', N'', N'', N'', N'', N'20000', N'20001', N'', N'在職', NULL, NULL)



