namespace DormAPI.DTOs
{
    public class StudentDepositDTO
    {
        public int DepositID { get; set; }
        public int StudentID { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime DepositDate { get; set; }
        public bool isRefunded { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class AddStudentDepositDTO
    {
        public int StudentID { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime DepositDate { get; set; }
    }
}
