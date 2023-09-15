UPDATE [employee].[Employee]
SET 
    [FirstName] = @FirstName
    ,[LastName] = @LastName
    ,[BirthDate] = @BirthDate
WHERE Id = @Id
SELECT @@ROWCOUNT