MERGE [employee].[Employee] AS T
USING
(
	SELECT * FROM  
	OPENJSON ( @json )  
	WITH (   
		[Id]            [int]           '$.Id',
		[FirstName]     [varchar](50)   '$.FirstName',
		[LastName]      [varchar](50)   '$.LastName',
		[BirthDate]     [date]          '$.BirthDate'
	) 
) AS S
ON T.[Id] = S.[Id]
WHEN MATCHED 
	AND T.[FirstName] <> S.[FirstName]
	OR T.[LastName] <> S.[LastName]
	OR T.[BirthDate] <> S.[BirthDate]
	THEN UPDATE SET 
		T.[FirstName] = S.[FirstName]
		,T.[LastName] = S.[LastName]
		,T.[BirthDate] = S.[BirthDate]
WHEN NOT MATCHED 
     THEN INSERT
	(
		[FirstName]
		,[LastName]
		,[BirthDate]
	)
	VALUES 
	(
		S.[FirstName]
		,S.[LastName]
		,S.[BirthDate]
	)
	OUTPUT Inserted.Id;