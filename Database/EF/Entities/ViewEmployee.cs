namespace DormAPI.Database.EF.Entities
{
    public partial class ViewEmployee
    {
        public int EmployeeId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmployeeTypeName { get; set; } = string.Empty;
    }
}
