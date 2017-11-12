IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmployeeInsert]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressSave]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddressSave]

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddressUpdate]

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddressUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AddressUpdate]
@AddressId int,
@City varchar(100),
@PostCode varchar(10),
@Street varchar(100),
@HouseNumber int,
@LocalNumber int = null
AS
BEGIN
	UPDATE Address
	SET City = @City, PostCode = @PostCode, Street = @Street, HouseNumber = @HouseNumber, LocalNumber = @LocalNumber
	WHERE AddressId = @AddressId
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
IF NOT EXISTS (SELECT EmployeeID FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName)
BEGIN INSERT INTO Employee (UserId, FirstName, LastName, AddressId)
Values (@UserId, @FirstName, @LastName, @AddressId) END
END'
END