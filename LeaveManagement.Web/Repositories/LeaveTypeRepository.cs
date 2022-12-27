using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        //now take db conext and pass on same copy. now register it in program.cs
        public LeaveTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
