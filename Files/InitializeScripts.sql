IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[PostCode] [varchar](10) NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[HouseNumber] [int] NOT NULL,
	[LocalNumber] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[Address] ([City], [PostCode], [Street], [HouseNumber], [LocalNumber]) VALUES ('Katowice', '41-xxx', 'Katowicka', '1', '2')
	INSERT [dbo].[Address] ([City], [PostCode], [Street], [HouseNumber], [LocalNumber]) VALUES ('Zabrze', '41-xxx', 'Zabrzanska', '11', '22')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contract](
	[ContractId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
	
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (1, 1, '2017-06-01', '2017-07-30')
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (1, 1, '2017-08-01', '2018-01-01')
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (2, 1, '2017-03-01', '2017-10-30')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[Employee] ([UserId], [AddressId], [FirstName], [LastName]) VALUES (1, 1, 'Jan', 'Kowalski')
	INSERT [dbo].[Employee] ([UserId], [AddressId], [FirstName], [LastName]) VALUES (3, 2, 'Mietek', 'Gwozdz')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('Janex', 'secretPassword', '2017-10-30')
	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('UserSecond', 'anotherPassword', '2017-09-30')
	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('Mietghar', 'abcd', '2017-10-15')
END