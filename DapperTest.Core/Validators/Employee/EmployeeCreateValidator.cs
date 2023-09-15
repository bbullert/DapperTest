using DapperTest.Core.Dto;
using FluentValidation;

namespace DapperTest.Core.Validators
{
    public class EmployeeCreateValidator : AbstractValidator<EmployeeCreate>
    {
        public EmployeeCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithName("First Name")
                .WithMessage(ValidationErrorMessage.Required)
                .MaximumLength(5)
                .WithMessage(ValidationErrorMessage.MaxLength);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithName("Last Name")
                .WithMessage(ValidationErrorMessage.Required)
                .MaximumLength(50)
                .WithMessage(ValidationErrorMessage.MaxLength);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithName("Birth Date")
                .WithMessage(ValidationErrorMessage.Required);
        }
    }
}
