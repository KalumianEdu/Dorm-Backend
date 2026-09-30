namespace DormAPI.DTOs
{
    public class PaymentDTO
    {
        public int rentInstallmentId { get; set; }
        public int paymentMethodId  { get; set; }
        public string notes { get; set; }
    }
}
