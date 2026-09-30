namespace DormAPI.Database.EF.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int PersonId { get; set; }


        public virtual Person Person { get; set; } = null!;
        public virtual  EmployeeType EmployeeType { get; set; } = null!;
    }
}
