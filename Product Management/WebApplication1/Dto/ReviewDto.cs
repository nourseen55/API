namespace WebApplication1.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }          // Unique identifier for the review
        public int ProductId { get; set; }   // Product being reviewed (or another entity)
        public string Comment { get; set; }  // The review text
        public int Rating { get; set; }      // Rating given by the user (e.g., 1-5)
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
            // When the review was created

    }
}
