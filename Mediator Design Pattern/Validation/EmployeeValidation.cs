using FluentValidation;
using Mediator_Design_Pattern.Models;

namespace Mediator_Design_Pattern.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Employee name is required").MinimumLength(3).MaximumLength(50).WithMessage("Employee name must be between 3 and 50");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Employee email is required").MinimumLength(10).MaximumLength(100).WithMessage("Employee name must be between 3 and 50").EmailAddress().WithMessage("Employee email is invalid");
            RuleFor(x => x.JoinDate).NotEmpty().WithMessage("Employee join date is required");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Employee salary is required").GreaterThan(0).WithMessage("Employee salary must be greater than 0");
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Employee department id is required").IsInEnum().WithMessage("Department is is invalid");
        }
    }
}
