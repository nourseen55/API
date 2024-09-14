namespace WebApplication1.Model
{
    public class Review
    {
        
            public int Id { get; set; }          // Unique identifier for the review
            public string UserId { get; set; }   // User who made the review
            public int ProductId { get; set; }   // Product being reviewed (or another entity)
            public string Comment { get; set; }  // The review text
            public int Rating { get; set; }      // Rating given by the user (e.g., 1-5)
            public DateTime CreatedAt { get; set; } // When the review was created

            public ApplicationUser User { get; set; } // Reference to the user who made the review
            public Product Product { get; set; }       // Reference to the product being reviewed
     }
    
}
