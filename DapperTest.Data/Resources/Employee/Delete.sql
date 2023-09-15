DELETE FROM [employee].[Employee]
WHERE Id = @Id
SELECT @@ROWCOUNT