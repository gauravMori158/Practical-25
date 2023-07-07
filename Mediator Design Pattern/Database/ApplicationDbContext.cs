using Microsoft.EntityFrameworkCore;
using Mediator_Design_Pattern.Models;
using System.Collections.Generic;

namespace Mediator_Design_Pattern.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<Employee> Employees { get; set; } = null!;
    }
}
