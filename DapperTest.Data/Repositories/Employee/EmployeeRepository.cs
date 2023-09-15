using Dapper;
using DapperTest.Data.Entities;
using DapperTest.Data.Resources.Employee;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using static Dapper.SqlMapper;

namespace DapperTest.Data.Repositories
{
    public class EmployeeRepository : Repository, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Employee> GetAsync(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = await connection.QueryAsync<Employee>(Sql.Select, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<Employee>(Sql.SelectAll);
                return result.ToList();
            }
        }

        public async Task<ISearchResult<Employee>> SearchAsync(EmployeeSearchCriteria criteria)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new
                {
                    criteria.Id,
                    criteria.FirstName,
                    criteria.LastName,
                    criteria.BirthDateFrom,
                    criteria.BirthDateTo,
                    criteria.Page,
                    criteria.PageSize,
                    criteria.SortBy,
                    criteria.SortOrder
                };
                var result = await connection.QueryAsync<Employee>(Sql.Search, param);

                return new SearchResult<Employee>()
                {
                    Page = criteria.Page,
                    PageSize = criteria.PageSize,
                    TotalRows = result.FirstOrDefault()?.TotalRows ?? 0,
                    Rows = result
                };
            }
        }

        public async Task<int> AddAsync(Employee entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new
                {
                    entity.FirstName,
                    entity.LastName,
                    entity.BirthDate
                };
                var result = await connection.QueryAsync<int>(Sql.Insert, param);
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<int>> AddRangeAsync(IEnumerable<Employee> entities)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { Json = JsonSerializer.Serialize(entities) };
                var result = await connection.QueryAsync<int>(Sql.InsertRange, param);
                return result.ToList();
            }
        }

        public async Task<bool> UpdateAsync(int id, Employee entity)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new
                {
                    id,
                    entity.FirstName,
                    entity.LastName,
                    entity.BirthDate
                };
                var result = await connection.QueryAsync<int>(Sql.Update, param);
                return result.First() != 0;
            }
        }

        public async Task<IEnumerable<int>> UpdateOrCreateRangeAsync(IEnumerable<Employee> entities)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { Json = JsonSerializer.Serialize(entities) };
                var result = await connection.QueryAsync<int>(Sql.UpdateOrCreateRange, param);
                return result.ToList();
            }
        }

        public bool Remove(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { id };
                var result = connection.Query<int>(Sql.Delete, param);
                return result.First() != 0;
            }
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var param = new { Ids = string.Join(';', ids) };
                connection.Execute(Sql.DeleteRange, param);
            }
        }
    }
}
