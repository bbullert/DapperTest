using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpPost("employees/bulk")]
        public async Task<IActionResult> CreateRangeAsync(EmployeeRange model)
        {
            try
            {
                var result = await _employeeService.CreateRangeAsync(model.Employees);
                return Created(result);
            }
            catch (HttpResponseException ex)
            {
                return Error(ex);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}