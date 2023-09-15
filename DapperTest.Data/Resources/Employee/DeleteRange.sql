DELETE FROM [employee].[Employee]
WHERE Id IN 
(
	SELECT [Value] FROM STRING_SPLIT(@Ids, ';')
)