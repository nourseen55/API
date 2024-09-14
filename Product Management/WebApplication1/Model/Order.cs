namespace WebApplication1.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // "Pending", "Shipped", "Completed", "Cancelled"
        public string Address { get; set; }
        public DateTime DateTime { get; }

        public bool IsInCart { get; set; } // Property to determine if this order is part of the cart

        public Order()
        {
            DateTime = DateTime.Now;
            IsInCart = true; // Default value for new orders
        }

        // Method to set the order as completed and remove it from the cart
        public void MarkAsCompleted()
        {
            Status = "Completed";
            IsInCart = false; // Order is no longer in the cart
        }

        // Method to calculate total price based on quantity and product price
        public void CalculateTotalPrice(decimal pricePerItem)
        {
            TotalPrice = Quantity * pricePerItem;
        }

        // Method to update the quantity of items in the cart
        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity > 0)
            {
                Quantity = newQuantity;
            }
        }

        // Method to check if the order is pending and still in the cart
        public bool IsPendingOrder()
        {
            return Status == "Pending" && IsInCart;
        }
    }
}
