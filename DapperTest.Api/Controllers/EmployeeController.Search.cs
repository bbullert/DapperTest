using DapperTest.Api.Model;
using DapperTest.Core.Exceptions;
using DapperTest.Data.Entities;
using DapperTest.Data.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpGet("employees")]
        [ProducesResponseType(typeof(ApiResponse<ISearchResult<object>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRangeAsync([FromQuery] EmployeeSearchCriteria criteria)
        {
            try
            {
                var result = await _employeeService.SearchAsync(criteria);
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
