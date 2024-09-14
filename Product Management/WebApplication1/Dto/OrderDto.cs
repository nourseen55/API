namespace WebApplication1.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public string Status { get; set; } //"Pending", "Shipped", "Completed", "Cancelled"
        public string Address { get; set; }
        public DateTime DateTime { get; }= DateTime.Now;
    }
}
