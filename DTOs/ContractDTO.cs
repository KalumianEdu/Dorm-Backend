namespace DormAPI.DTOs
{
    public class ContractDTO
    {
        public string contractName { get; set; }
        public DateTime contractStartDate { get; set; }
        public DateTime contractEndDate { get; set; }
        public float totalAmount { get; set; }
        public float additionalFees { get; set; }
        public float discount { get; set; }
        public float monthlyAmount { get; set; }
        public int numberOfInstallments { get; set; }
        public int studentId { get; set; }
    }
}
