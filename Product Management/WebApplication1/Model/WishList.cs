using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class WishList
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        [JsonIgnore]
        public virtual ICollection<WishlistItem>? WishlistItems { get; set; } = new List<WishlistItem>();
    }
}
