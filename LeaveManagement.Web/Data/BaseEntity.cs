namespace LeaveManagement.Web.Data
{
    public abstract class BaseEntity
    {
        //an abstract class can't be initiated on it's own. it must be inherited
        //keep here common columns for all your classes or which are repeated columns
        public int ID { get; set; } //EF core automatically takes it as pk
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
