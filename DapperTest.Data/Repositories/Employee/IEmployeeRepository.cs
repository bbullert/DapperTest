using DapperTest.Data.Entities;

namespace DapperTest.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<int> AddAsync(Employee entity);
        Task<IEnumerable<int>> AddRangeAsync(IEnumerable<Employee> entities);
        Task<Employee> GetAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<ISearchResult<Employee>> SearchAsync(EmployeeSearchCriteria criteria);
        bool Remove(int id);
        void RemoveRange(IEnumerable<int> ids);
        Task<bool> UpdateAsync(int id, Employee entity);
        Task<IEnumerable<int>> UpdateOrCreateRangeAsync(IEnumerable<Employee> entities);
    }
}