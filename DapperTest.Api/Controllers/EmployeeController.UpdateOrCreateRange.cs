using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpPut("employees/bulk")]
        public async Task<IActionResult> UpdateOrCreateRangeAsync(EmployeeRange model)
        {
            try
            {
                var result = await _employeeService.UpdateOrCreateRangeAsync(model.Employees);
                return Ok(result);
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