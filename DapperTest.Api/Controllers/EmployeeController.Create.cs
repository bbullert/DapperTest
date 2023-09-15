using DapperTest.Api.Model;
using DapperTest.Core.Dto;
using DapperTest.Core.Exceptions;
using DapperTest.Core.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    public partial class EmployeeController
    {
        [HttpPost("employees")]
        [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<ValidationResult>), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeCreate model)
        {
            try
            {
                var validationResult = _validator.Validate(model);
                validationResult.AddToModelState(ModelState);

                if (!ModelState.IsValid)
                    return UnprocessableEntity(ModelState);

                var result = await _employeeService.CreateAsync(model);
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