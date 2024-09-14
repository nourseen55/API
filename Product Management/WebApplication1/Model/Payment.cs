namespace WebApplication1.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } //"Stripe", "PayPal"
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
    }
}
