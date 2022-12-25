using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Data
{
    //DbContext is for normal db tables. IdentityDBContext is for user user specific tables
    //now we will pass <Employee> while inheriting below.
    //register any new class created here o cerate corresponding db table
    //after registering here, do "add-migration" in pmc 
    public class ApplicationDbContext : IdentityDbContext<Employee> //<Employee> is added
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; } //rgister your class to map to a db table here
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; } //rgister your class to map to a db table here
    }
}