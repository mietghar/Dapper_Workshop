IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EmployeeInsert]

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[EmployeeInsert]
@FirstName varchar(50),
@LastName varchar(50) = null,
@AddressId int
AS
BEGIN
IF NOT EXISTS (SELECT EmployeeID FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName)
BEGIN INSERT INTO Employee (FirstName, LastName, AddressId)
Values (@FirstName, @LastName, @AddressId) END
END'
END