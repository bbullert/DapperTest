using Dto = DapperTest.Core;
using Entities = DapperTest.Data;
using DapperTest.Data.Repositories;
using DapperTest.Core.Dto;

namespace DapperTest.Core.Services
{
    public partial class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository
            )
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var result = await _employeeRepository.GetAsync(id);
            if (result == null) return null;
            var employee = Employee.FromEntity(result);

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var result = await _employeeRepository.GetAllAsync();
            var employees = result.Select(x => Employee.FromEntity(x)).ToList();

            return employees;
        }

        public async Task<Data.Entities.ISearchResult<Employee>> SearchAsync(Data.Entities.EmployeeSearchCriteria criteria)
        {
            var result = await _employeeRepository.SearchAsync(criteria);
            var employees = result.Rows.Select(x => Employee.FromEntity(x)).ToList();

            return new Data.Entities.SearchResult<Employee>() {
                Page = result.Page,
                PageSize = result.PageSize,
                TotalRows = result.TotalRows,
                Rows = employees,
            };
        }

        public async Task<int> CreateAsync(EmployeeCreate employee)
        {
            var result = await _employeeRepository.AddAsync(employee.ToEntity());
            return result;
        }

        public async Task<IEnumerable<int>> CreateRangeAsync(IEnumerable<Employee> employees)
        {
            var entities = employees.Select(x => x.ToEntity()).ToList();
            var result = await _employeeRepository.AddRangeAsync(entities);
            return result;
        }

        public async Task<bool> UpdateAsync(int id, EmployeeCreate employee)
        {
            var result = await _employeeRepository.UpdateAsync(id, employee.ToEntity());
            return result;
        }

        public async Task<IEnumerable<int>> UpdateOrCreateRangeAsync(IEnumerable<Employee> employees)
        {
            var entities = employees.Select(x => x.ToEntity()).ToList();
            var result = await _employeeRepository.UpdateOrCreateRangeAsync(entities);
            return result;
        }

        public bool Remove(int id)
        {
            return _employeeRepository.Remove(id);
        }

        public void RemoveRange(IEnumerable<int> ids)
        {
            _employeeRepository.RemoveRange(ids);
        }
    }
}
