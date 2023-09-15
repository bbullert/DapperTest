INSERT INTO [employee].[Employee]
(
    [FirstName]
    ,[LastName]
    ,[BirthDate]
) 
OUTPUT Inserted.Id
VALUES 
(
    @FirstName
    ,@LastName
    ,@BirthDate
)
