using MediatR;
using Microsoft.EntityFrameworkCore;
using Mediator_Design_Pattern.Database;
using Mediator_Design_Pattern.Models;

namespace Mediator_Design_Pattern.Mediator
{
    public class GetEmployeeByIdQuery : IRequest<Employee?>
    {
        public int Id { get; set; } 
        public class GetAllEmployeesQueryHanlder : IRequestHandler<GetEmployeeByIdQuery, Employee?>
        {
            private readonly ApplicationDbContext _context;
            public GetAllEmployeesQueryHanlder(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(emp => emp.Id == request.Id);
                return employee;
            }
        }
    }
}
