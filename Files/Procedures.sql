IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[PostCode] [varchar](10) NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[HouseNumber] [int] NOT NULL,
	[LocalNumber] [int] NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[Address] ([City], [PostCode], [Street], [HouseNumber], [LocalNumber]) VALUES ('Katowice', '41-xxx', 'Katowicka', '1', '2')
	INSERT [dbo].[Address] ([City], [PostCode], [Street], [HouseNumber], [LocalNumber]) VALUES ('Zabrze', '41-xxx', 'Zabrzanska', '11', '22')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contract]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contract](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
	
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (1, 1, '2017-06-01', '2017-07-30')
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (1, 1, '2017-08-01', '2018-01-01')
	INSERT [dbo].[Contract] ([EmployeeId], [Type], [DateFrom], [DateTo]) VALUES (2, 1, '2017-03-01', '2017-10-30')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[Employee] ([UserId], [AddressId], [FirstName], [LastName]) VALUES (1, 1, 'Jan', 'Kowalski')
	INSERT [dbo].[Employee] ([UserId], [AddressId], [FirstName], [LastName]) VALUES (3, 2, 'Mietek', 'Gwozdz')
	INSERT [dbo].[Employee] ([UserId], [AddressId], [FirstName], [LastName]) VALUES (2, 1, '£ukasz', 'Szustak')
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('Janex', 'secretPassword', '2017-10-30')
	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('UserSecond', 'anotherPassword', '2017-09-30')
	INSERT [dbo].[User] ([UserName], [Password], [ModifiedDate]) VALUES ('Mietghar', 'abcd', '2017-10-15')
END

IF NOT EXISTS (SELECT * FROM Employee)
BEGIN
INSERT INTO Employee (UserId, AddressId, FirstName, LastName) 
VALUES (1, 1, 'Jan', 'Kowalski'), (3, 2, 'Mietek', 'Gwozdz'), (2, 1, '£ukasz', 'Szustak')
END

IF NOT EXISTS (SELECT * FROM Address)
BEGIN
INSERT INTO Address (City, PostCode, Street, HouseNumber, LocalNumber) 
VALUES ('Katowice', '41-xxx', 'Katowicka', '1', '2'), ('Zabrze', '41-xxx', 'Zabrzanska', '11', '22')
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmployeeInsert]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddressSave]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddressUpdate]

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AddressUpdate]
@Id int,
@City varchar(100),
@PostCode varchar(10),
@Street varchar(100),
@HouseNumber int,
@LocalNumber int = null
AS
BEGIN
	UPDATE Address
	SET City = @City, PostCode = @PostCode, Street = @Street, HouseNumber = @HouseNumber, LocalNumber = @LocalNumber
	WHERE Id = @Id
END'
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressSave]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AddressSave]
@City varchar(100),
@PostCode varchar(10),
@Street varchar(100),
@HouseNumber int,
@LocalNumber int = null
AS
BEGIN
	INSERT INTO Address (City, PostCode, Street, HouseNumber, LocalNumber)
	Values (@City, @PostCode, @Street, @HouseNumber, @LocalNumber)
END'
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EmployeeInsert]
@FirstName varchar(50),
@LastName varchar(50) = null,
@AddressId int,
@UserId int
AS
BEGIN
IF NOT EXISTS (SELECT Id FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName)
BEGIN INSERT INTO Employee (UserId, FirstName, LastName, AddressId)
Values (@UserId, @FirstName, @LastName, @AddressId) END
END'
END