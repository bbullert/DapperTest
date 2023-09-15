using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpDelete("employees/bulk")]
        public IActionResult RemoveRange(EmployeeRemoveRange range)
        {
            try
            {
                _employeeService.RemoveRange(range.Ids);
                return Ok();
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