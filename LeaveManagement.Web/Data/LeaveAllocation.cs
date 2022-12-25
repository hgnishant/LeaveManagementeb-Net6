using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Data
{

    //you need to register it in ApplicationDbContext.cs
    public class LeaveAllocation : BaseEntity
    {
       // public int ID { get; set; } //comes from baseentity
        public int NumberOfDays { get; set; }

        [ForeignKey("LeaveTypeId")] //this will convert LeaveTypeId field in FK, although this annotation is not required as EF Core knows bcoz of below naming conventions 
        public LeaveType LeaveType { get; set; } //this will never translate in a column. it only gives reference for creating an fk
        public int LeaveTypeId { get; set; } //naming convention is very important

        public string EmployeId { get; set; }
        //public DateTime DateCreated { get; set; } column comes from baseEntitiy
        //public DateTime DateModified { get; set; }        column comes from baseEntitiy

    }
}
