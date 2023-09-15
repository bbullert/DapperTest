using DapperTest.Api.Model;
using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpGet("employees/{id}")]
        [ProducesResponseType(typeof(ApiResponse<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var result = await _employeeService.GetAsync(id);
                if (result == null) 
                    return NotFound();

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