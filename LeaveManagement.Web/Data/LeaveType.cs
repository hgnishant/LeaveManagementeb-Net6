namespace LeaveManagement.Web.Data
{
    //you need to rgister it in ApplicationDbContext.cs
    public class LeaveType : BaseEntity
    {
        //don't use this file to show data on view - respect Single Responsibility principle
       // public int ID { get; set; } //EF core automatically takes it as pk . column comes from baseEntitiy
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        //public DateTime DateCreated { get; set; } column comes from baseEntitiy
        // public DateTime DateModified { get; set; } column comes from baseEntitiy

    }
}
