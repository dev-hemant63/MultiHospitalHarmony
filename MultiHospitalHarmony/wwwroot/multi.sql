USE [DB_MultiHospitalHarmony]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_RoleFix]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[fn_RoleFix](@RoleId int)
returns varchar(240)
AS
Begin
	Declare @RolePreFix varchar(240)
	Select @RolePreFix = PreFix from ApplicationRole Where Id = @RoleId
	return @RolePreFix
End
GO
/****** Object:  Table [dbo].[ApplicationRole]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
	[PreFix] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[TID] [int] NULL,
	[ServiceId] [int] NULL,
	[Opening] [numeric](10, 2) NULL,
	[Amount] [numeric](10, 2) NULL,
	[Closing] [numeric](10, 2) NULL,
	[TrType] [varchar](2) NULL,
	[EntryAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterCity]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterCity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [varchar](50) NOT NULL,
	[StateId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterModule]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](240) NULL,
	[DisplayName] [varchar](240) NULL,
	[IsActive] [bit] NULL,
	[EntryAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterPages]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NULL,
	[PageName] [varchar](240) NULL,
	[Controller] [varchar](240) NULL,
	[Action] [varchar](240) NULL,
	[IsActive] [bit] NULL,
	[EntryAt] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterState]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RunTimeError]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RunTimeError](
	[Id] [int] NULL,
	[ErrorClass] [nvarchar](max) NULL,
	[Error] [nvarchar](max) NULL,
	[ErrorMethod] [nvarchar](max) NULL,
	[EntryOn] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserModule]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ModuleId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MobileNo] [varchar](15) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](150) NULL,
	[Address] [varchar](100) NOT NULL,
	[CityId] [int] NOT NULL,
	[StateId] [int] NOT NULL,
	[ZipCode] [int] NOT NULL,
	[Photo] [varchar](250) NOT NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[ModifyAt] [datetime] NULL,
	[EntryBy] [int] NULL,
	[UserName] [varchar](150) NULL,
	[FullName] [varchar](240) NULL,
	[Tehsil] [varchar](240) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [numeric](18, 2) NULL,
	[LeanAmount] [numeric](18, 2) NULL,
	[LastUpdate] [datetime] NULL,
	[UserId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ApplicationRole] ON 
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (1, N'SuperAdmin', NULL)
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (2, N'SuperDistributor', N'SDABCDE')
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (3, N'Distributor', N'ADABCDE')
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (4, N'Agent', N'AGABCDE')
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (5, N'Hospital', N'HSABCDE')
GO
INSERT [dbo].[ApplicationRole] ([Id], [Role], [PreFix]) VALUES (6, N'Doctor', N'DRABCDE')
GO
SET IDENTITY_INSERT [dbo].[ApplicationRole] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterCity] ON 
GO
INSERT [dbo].[MasterCity] ([Id], [CityName], [StateId]) VALUES (1, N'Lucknow', 1)
GO
INSERT [dbo].[MasterCity] ([Id], [CityName], [StateId]) VALUES (2, N'Kheri', 1)
GO
SET IDENTITY_INSERT [dbo].[MasterCity] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterModule] ON 
GO
INSERT [dbo].[MasterModule] ([Id], [Name], [DisplayName], [IsActive], [EntryAt]) VALUES (1, N'UserManagement', N'User Management', 1, CAST(N'2024-02-27T18:24:50.560' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[MasterModule] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterPages] ON 
GO
INSERT [dbo].[MasterPages] ([Id], [ModuleId], [PageName], [Controller], [Action], [IsActive], [EntryAt]) VALUES (1, 1, N'Create User', N'User', N'Create', 1, CAST(N'2024-02-27T18:29:31.100' AS DateTime))
GO
INSERT [dbo].[MasterPages] ([Id], [ModuleId], [PageName], [Controller], [Action], [IsActive], [EntryAt]) VALUES (2, 1, N'User List', N'User', N'UserList', 1, CAST(N'2024-02-29T15:33:17.203' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[MasterPages] OFF
GO
SET IDENTITY_INSERT [dbo].[MasterState] ON 
GO
INSERT [dbo].[MasterState] ([Id], [StateName]) VALUES (1, N'Uttar Pradesh')
GO
SET IDENTITY_INSERT [dbo].[MasterState] OFF
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'AccountService', N'Cannot implicitly convert type ''int'' to ''string''', N'Login', CAST(N'2024-02-27T17:32:34.557' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'Cannot perform runtime binding on a null reference', N'GetSubMinus', CAST(N'2024-02-28T17:09:59.850' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'AccountService', N'One or more errors occurred. (Invalid column name ''FirstName''.
Invalid column name ''MidileName''.
Invalid column name ''LastName''.)', N'Login', CAST(N'2024-02-29T05:37:55.767' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'AccountService', N'One or more errors occurred. (Procedure or function ''Proc_Login'' expects parameter ''@EmailId'', which was not supplied.)', N'Login', CAST(N'2024-02-29T05:46:21.360' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'One or more errors occurred. (Unable to cast object of type ''Microsoft.Data.ProviderBase.DbConnectionClosedConnecting'' to type ''Microsoft.Data.SqlClient.SqlInternalConnectionTds''.)', N'GetCity', CAST(N'2024-02-29T13:41:46.570' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'One or more errors occurred. (The connection does not support MultipleActiveResultSets.)', N'GetState', CAST(N'2024-02-29T13:43:11.093' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'The connection does not support MultipleActiveResultSets.', N'GetCity', CAST(N'2024-02-29T14:04:34.780' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'Unable to cast object of type ''Microsoft.Data.ProviderBase.DbConnectionClosedConnecting'' to type ''Microsoft.Data.SqlClient.SqlInternalConnectionTds''.', N'GetState', CAST(N'2024-02-29T14:33:17.860' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'Procedure or function ''Proc_GetUserList'' expects parameter ''@loginId'', which was not supplied.', N'GetUserList', CAST(N'2024-02-29T15:34:19.850' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'Procedure or function ''Proc_GetUserList'' expects parameter ''@loginId'', which was not supplied.', N'GetUserList', CAST(N'2024-02-29T15:35:57.170' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-02-29T15:39:47.707' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T13:55:23.850' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T13:57:01.700' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T13:57:05.010' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T13:59:37.000' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T15:54:39.770' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T15:56:19.350' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T15:58:11.030' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T15:58:41.890' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T16:02:17.350' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T16:03:27.683' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T16:04:11.463' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T16:08:13.437' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T16:17:50.720' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T16:20:59.290' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T16:21:10.710' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'Execution Timeout Expired.  The timeout period elapsed prior to completion of the operation or the server is not responding.', N'GetUserList', CAST(N'2024-03-01T16:23:59.383' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'The connection does not support MultipleActiveResultSets.', N'GetUserList', CAST(N'2024-03-01T16:24:10.533' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'AccountService', N'One or more errors occurred. (Procedure or function ''Proc_Login'' expects parameter ''@EmailId'', which was not supplied.)', N'Login', CAST(N'2024-02-29T08:03:17.347' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-02-29T17:57:17.013' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'One or more errors occurred. (Cannot insert the value NULL into column ''Photo'', table ''DB_MultiHospitalHarmony.dbo.Users''; column does not allow nulls. INSERT fails.
The statement has been terminated.)', N'Create', CAST(N'2024-03-01T14:48:42.543' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T15:47:15.263' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T15:47:44.557' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T15:48:03.130' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-03-01T15:48:32.893' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'One or more errors occurred. (The connection does not support MultipleActiveResultSets.)', N'Create', CAST(N'2024-03-01T15:48:33.007' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'One or more errors occurred. (The connection does not support MultipleActiveResultSets.)', N'GetCity', CAST(N'2024-02-29T13:39:48.767' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'UserService', N'Procedure or function ''Proc_GetUserList'' expects parameter ''@Id'', which was not supplied.', N'GetUserList', CAST(N'2024-02-29T17:52:54.580' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'No such host is known. (api.postalpincode.in:443)', N'GetDetailsByPincode', CAST(N'2024-02-29T17:54:28.297' AS DateTime))
GO
INSERT [dbo].[RunTimeError] ([Id], [ErrorClass], [Error], [ErrorMethod], [EntryOn]) VALUES (NULL, N'CommonService', N'Procedure or function ''Proc_GetUserRole'' expects parameter ''@loginId'', which was not supplied.', N'GetUserRole', CAST(N'2024-03-01T15:44:05.270' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[UserModule] ON 
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (2, 9, 1)
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (3, 10, 1)
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (4, 13, 1)
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (5, 14, 1)
GO
INSERT [dbo].[UserModule] ([Id], [UserId], [ModuleId]) VALUES (6, 11, 1)
GO
SET IDENTITY_INSERT [dbo].[UserModule] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (1, 1, N'9999999999', N'superadmin@gmail.com', N'202cb962ac59075b964b07152d234b70', N'123 Main St', 1, 1, 12345, N'profile.png', 1, CAST(N'2024-02-25T16:50:58.503' AS DateTime), CAST(N'2024-02-25T16:50:58.503' AS DateTime), NULL, N'SuperAdmin', N'SuperAdmin', N'Dhaurahra')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (6, 2, N'07766776690', N'y@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 226011, N'', 1, CAST(N'2024-02-29T14:44:59.740' AS DateTime), NULL, 1, N'SDABCDE6', N'super distributor', N'Dhaurahra')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (9, 3, N'9066776655', N'hgfhg@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 678987, N'', 1, CAST(N'2024-03-01T14:51:38.493' AS DateTime), NULL, 1, N'ADQXRZ837703', N'Demo Distributor', N'Demo')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (10, 4, N'8766776655', N'agent@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 223456, N'', 1, CAST(N'2024-03-01T15:48:13.750' AS DateTime), NULL, 9, N'AGZGWL301718', N'Demo Agent', N'sder')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (11, 5, N'8978677867', N'hospital@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 678987, N'', 1, CAST(N'2024-03-01T15:58:39.517' AS DateTime), NULL, 10, N'HSMUCO336781', N'Nova', N'ddfd')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (12, 5, N'7856675645', N'tyuytu@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 678987, N'', 1, CAST(N'2024-03-01T16:08:33.037' AS DateTime), NULL, 9, N'HSSXDO067911', N'KGMU', N'fghfhgh')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (13, 2, N'7866776655', N'y@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 678987, N'', 1, CAST(N'2024-03-01T16:17:58.990' AS DateTime), NULL, 1, N'SDTCAL605912', N'Super Distributor', N'dfgfdgf')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (14, 3, N'8966776655', N'y@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 678987, N'', 1, CAST(N'2024-03-01T16:21:08.603' AS DateTime), NULL, 13, N'ADOHTF893639', N'sdfsf', N'gfhgf')
GO
INSERT [dbo].[Users] ([Id], [RoleId], [MobileNo], [Email], [Password], [Address], [CityId], [StateId], [ZipCode], [Photo], [IsActive], [CreatedAt], [ModifyAt], [EntryBy], [UserName], [FullName], [Tehsil]) VALUES (15, 6, N'876787678', N'78667@gmail.com', N'202cb962ac59075b964b07152d234b70', N'csfsdfsdcfs', 1, 1, 786756, N'', 1, CAST(N'2024-03-01T18:25:48.353' AS DateTime), NULL, 11, N'DRKIU585182', N'Doctor one 1', N'fdfrtg')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Wallets] ON 
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (1, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-02-29T05:07:02.290' AS DateTime), 1)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (4, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-02-29T14:44:59.750' AS DateTime), 6)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (5, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T14:51:38.503' AS DateTime), 9)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (9, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T16:17:58.997' AS DateTime), 13)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (10, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T16:21:08.610' AS DateTime), 14)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (6, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T15:48:13.753' AS DateTime), 10)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (7, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T15:58:39.520' AS DateTime), 11)
GO
INSERT [dbo].[Wallets] ([Id], [Amount], [LeanAmount], [LastUpdate], [UserId]) VALUES (8, CAST(0.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), CAST(N'2024-03-01T16:08:33.040' AS DateTime), 12)
GO
SET IDENTITY_INSERT [dbo].[Wallets] OFF
GO
/****** Object:  StoredProcedure [dbo].[Proc_CreateUser]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_CreateUser]
@Id int,
@RoleId int,
@FullName varchar(240),
@MobileNo varchar(240),
@Email varchar(240) = '',
@Password varchar(240),
@Address varchar(240),
@CityId int,
@StateId int,
@ZipCode int,
@Tehsil varchar(150),
@UserName varchar(240),
@EntryBy int
AS
BEGIN
	IF @RoleId = 2 AND @EntryBy != 1
	BEGIN
		Select -1 StatusCode,'Access Denied!' [Message]
		return
	END
	
	IF @Id = 0
	BEGIN
		IF Exists(select 1 from Users where MobileNo = @MobileNo)
		begin
			Select -1 StatusCode,'The mobile number provided is already associated with an existing user.' [Message]
			return
		end
		Insert into Users(RoleId,FullName,MobileNo,Email,[Password],[Address],CityId,StateId,ZipCode,IsActive,CreatedAt,EntryBy,Tehsil,UserName,Photo)
		Values(@RoleId,@FullName,@MobileNo,@Email,@Password,@Address,@CityId,@StateId,@ZipCode,1,GETDATE(),@EntryBy,@Tehsil,@UserName,'');
		Select 1 StatusCode,'User created successfully.' [Message]
	END
	Else
	BEGIN
		Update Users SET FullName = @FullName,MobileNo = @MobileNo,Email = @Email,[Address] = @Address,CityId = @CityId,StateId = @StateId,ZipCode = @ZipCode Where Id = @Id
		Select 1 StatusCode,'User updated successfully.' [Message]
	END
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetAreaDetails]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Proc_GetAreaDetails]
@CityName varchar(240),
@StateName varchar(240)
AS
BEGIN
	Declare @CityId int,@StateId int
	Select @CityId = Id from MasterCity Where CityName = @CityName
	Select @StateId = Id from MasterState Where StateName = @StateName
	if(Isnull(@StateId,0) = 0)
	begin
		insert into MasterState values(@StateName);
		set @StateId = SCOPE_IDENTITY();
	end
	if(Isnull(@CityId,0) = 0)
	begin
		insert into MasterCity values(@CityName,@StateId);
		set @CityId = SCOPE_IDENTITY();
	end
	Select @CityId CityId,@StateId StateId
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetMinus]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Proc_GetMinus 1
CREATE proc [dbo].[Proc_GetMinus]
@UserId int
AS
BEGIN
	select 1 StatusCode,'Success' [Message],mm.Id,mm.DisplayName from MasterModule mm
	inner join UserModule um on um.ModuleId = mm.Id
	where um.UserId = @UserId and ISNULL(mm.IsActive,0) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetSubMinus]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Proc_GetSubMinus 9
CREATE proc [dbo].[Proc_GetSubMinus]
@UserId int
AS
BEGIN
	select 1 StatusCode,'Success' [Message],mp.Controller,mp.[Action],mp.ModuleId,mp.PageName from MasterPages mp 
	inner join UserModule um on mp.ModuleId = um.ModuleId and um.UserId = @UserId
	where mp.ModuleId IN(Select ModuleId from UserModule where UserId = @UserId)
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetUserList]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Proc_GetUserList 15,15
CREATE proc [dbo].[Proc_GetUserList]
@loginId int,
@Id int = 0
AS
BEGIN
	If @Id != 0
	begin
		Select u.Id,u.FullName,u.UserName,u.Email,u.MobileNo,u.[Address],c.CityName,s.StateName,u.Tehsil,u.IsActive,u.CreatedAt,w.Amount Balance,u.RoleId,u.CityId,u.StateId,u.ZipCode,u.Tehsil,
			ar.Role,u2.FullName Parent
		from Users u 
		inner join ApplicationRole ar on u.RoleId = ar.Id
		inner join MasterCity c on u.CityId = c.Id
		left join Wallets w on u.Id = w.UserId
		join Users u2 on u.EntryBy = u2.Id
		inner join MasterState s on u.StateId = s.Id where u.Id = @Id
	end
	else
	begin
		Select u.Id,u.FullName,u.UserName,u.Email,u.MobileNo,u.[Address],c.CityName,s.StateName,u.Tehsil,u.IsActive,u.CreatedAt,w.Amount Balance,u.RoleId,u.CityId,u.StateId,u.ZipCode,u.Tehsil,
			ar.Role,u2.FullName Parent
		from Users u 
		inner join ApplicationRole ar on u.RoleId = ar.Id
		inner join MasterCity c on u.CityId = c.Id
		left join Wallets w on u.Id = w.UserId
		join Users u2 on u.EntryBy = u2.Id
		inner join MasterState s on u.StateId = s.Id where (u.EntryBy = @loginId or @loginId = 1) and u.Id != 1 and (u.Id = @Id or @Id = 0)
	end
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_GetUserRole]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Proc_GetUserRole 9
CREATE proc [dbo].[Proc_GetUserRole]
@loginId int
AS
Begin
	Declare @RoleId int
	select @RoleId = RoleId from Users where Id = @loginId
	select * from ApplicationRole where Id > @RoleId
End
GO
/****** Object:  StoredProcedure [dbo].[Proc_Login]    Script Date: 02-03-2024 02:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Proc_Login 'superadmin@gmail.com','202cb962ac59075b964b07152d234b70'
CREATE proc [dbo].[Proc_Login]
@UserName varchar(50),
@Password varchar(50)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Users WHERE UserName = @UserName AND [Password] = @Password)
	BEGIN
		SELECT -1 StatusCode,'Invalid email or passoword.' [Message]
		return
	END
	IF NOT EXISTS(SELECT 1 FROM Users WHERE UserName = @UserName AND [Password] = @Password AND ISNULL(IsActive,0) = 1)
	BEGIN
		SELECT -1 StatusCode,'I am sorry, but I am not an active contact for admin or support.' [Message]
		return
	END
	SELECT 1 StatusCode,'Success.' [Message],u.Id,u.RoleId,u.FullName,u.MobileNo,u.Email,u.[Address],
			u.CityId,u.StateId,u.ZipCode,u.Photo,a.Role
	FROM Users(nolock) u
		Inner Join ApplicationRole a on u.RoleId = a.Id
	WHERE u.UserName = @UserName AND u.[Password] = @Password AND ISNULL(u.IsActive,0) = 1
END
GO
