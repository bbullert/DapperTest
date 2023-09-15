using DapperTest.Core.Dto;

namespace DapperTest.Core.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(EmployeeCreate employee);
        Task<IEnumerable<int>> CreateRangeAsync(IEnumerable<Employee> employees);
        Task<Employee> GetAsync(int id);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Data.Entities.ISearchResult<Employee>> SearchAsync(Data.Entities.EmployeeSearchCriteria criteria);
        bool Remove(int id);
        void RemoveRange(IEnumerable<int> ids);
        Task<bool> UpdateAsync(int id, EmployeeCreate employee);
        Task<IEnumerable<int>> UpdateOrCreateRangeAsync(IEnumerable<Employee> employees);
    }
}