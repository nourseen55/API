using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class WishlistItem
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [JsonIgnore]
        [ForeignKey("Wishlist")]
        public int? WishlistId { get; set; }
        public WishList? Wishlist { get; set; }
    }
}