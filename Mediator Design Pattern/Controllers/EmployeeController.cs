using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mediator_Design_Pattern.Models;
using Mediator_Design_Pattern.Validation;
using Mediator_Design_Pattern.Mediator;

namespace Mediator_Design_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            EmployeeValidation validationRules = new EmployeeValidation();
            ValidationResult result = validationRules.Validate(employee);
            if (result.IsValid)
            {
                CreateEmployeeCommand command = new CreateEmployeeCommand() { Name = employee.Name, Email = employee.Email, JoinDate = employee.JoinDate, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return Ok(await _mediator.Send(command));
            }
            return BadRequest(result.Errors.Select(item => new { item.PropertyName, item.ErrorMessage }));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery())); ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });
            if(emp != null)
            {
                return Ok(emp);
            }
            else
            {
                return NotFound("Employee with this id could not be found");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            EmployeeValidation validationRules = new EmployeeValidation();
            ValidationResult result = validationRules.Validate(employee);
            if (result.IsValid)
            {
                UpdateEmployeeCommand command = new UpdateEmployeeCommand() { Id = id, Name = employee.Name, Email = employee.Email, JoinDate = employee.JoinDate, Salary = employee.Salary, DepartmentId = employee.DepartmentId };

                return Ok(await _mediator.Send(command));
            }
            return BadRequest(result.Errors.Select(item => new { item.PropertyName, item.ErrorMessage }));
        }
    }
}
