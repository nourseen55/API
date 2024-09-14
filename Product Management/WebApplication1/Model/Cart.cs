namespace WebApplication1.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public string userid { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return items.Sum(item => item.Product.Price * item.Quantity);
            }
        }
        public List<CartItem>? items { get; set; }=new List<CartItem>();
    }
}
