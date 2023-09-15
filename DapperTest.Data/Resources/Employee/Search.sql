--DECLARE @Id INT = NULL
--DECLARE @FirstName NVARCHAR(MAX) = NULL
--DECLARE @LastName NVARCHAR(MAX) = NULL
--DECLARE @BirthDateFrom DATE = NULL
--DECLARE @BirthDateTo DATE = NULL

--DECLARE @Page INT = 1
--DECLARE @PageSize INT = 10
--DECLARE @SortBy NVARCHAR(MAX) = NULL
--DECLARE @SortOrder NVARCHAR(MAX) = NULL

SELECT 
    [Id]
    ,[FirstName]
    ,[LastName]
    ,[BirthDate]
	,COUNT(*) OVER() TotalRows
FROM 
    [employee].[Employee]
WHERE
    ( @Id IS NULL OR [Id] = @Id ) AND 
    ( @FirstName IS NULL OR [FirstName] LIKE '%' + @FirstName + '%' ) AND 
    ( @LastName IS NULL OR [LastName] LIKE '%' + @LastName + '%' ) AND 
    ( @BirthDateFrom IS NULL OR [BirthDate] >= @BirthDateFrom ) AND 
	( @BirthDateTo IS NULL OR [BirthDate] <= @BirthDateTo )
ORDER BY 
	CASE WHEN @SortBy = 'Id' AND @SortOrder = 'DESC' THEN [Id] END DESC,
	CASE WHEN @SortBy = 'Id' THEN [Id] END,
	CASE WHEN @SortBy = 'FirstName' AND @SortOrder = 'DESC' THEN [FirstName] END DESC,
	CASE WHEN @SortBy = 'FirstName' THEN [FirstName] END,
	CASE WHEN @SortBy = 'LastName' AND @SortOrder = 'DESC' THEN [LastName] END DESC,
	CASE WHEN @SortBy = 'LastName' THEN [LastName] END,
	CASE WHEN @SortBy = 'BirthDate' AND @SortOrder = 'DESC' THEN [BirthDate] END DESC,
	CASE WHEN @SortBy = 'BirthDate' THEN [BirthDate] END
OFFSET ( @Page - 1 ) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY
