INSERT INTO [employee].[Employee]
(
    [FirstName]
    ,[LastName]
    ,[BirthDate]
) 
OUTPUT Inserted.Id
SELECT * FROM  
OPENJSON ( @json )  
WITH (   
	[FirstName]     [varchar](50)   '$.FirstName',
	[LastName]      [varchar](50)   '$.LastName',
	[BirthDate]     [date]          '$.BirthDate'
) 
