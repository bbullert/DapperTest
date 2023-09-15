using DapperTest.Core.Dto;
using DapperTest.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public partial class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IValidator<EmployeeCreate> _validator;

        public EmployeeController(
            IEmployeeService employeeService, 
            IValidator<EmployeeCreate> validator)
        {
            _employeeService = employeeService;
            _validator = validator;
        }
    }
}