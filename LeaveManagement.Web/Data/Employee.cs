using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Web.Data
{
    //we are creating this class as we re nothappy with columns present in aspnetusers table
    //nherit from IdentityUser
    //now pass this class in program.cs where IdentityUser is being passed
    //after making changes in prgram.cs and applicationdbcontext.cs use pkg mgr console
    //and add this additional info :  "add-migration ExtendedUserTable" -- this adds a file in migration folder
    //then use update-database to add this new table to db
    public class Employee : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
