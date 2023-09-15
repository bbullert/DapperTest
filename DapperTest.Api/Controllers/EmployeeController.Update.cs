using DapperTest.Api.Model;
using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpPatch("employees/{id}")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeCreate model)
        {
            try
            {
                var validationResult = _validator.Validate(model);
                validationResult.AddToModelState(ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _employeeService.UpdateAsync(id, model);
                if (!result)
                    return NotFound();

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