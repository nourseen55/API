using System.Text.Json.Serialization;
using WebApplication1.Model;

namespace WebApplication1.Dto
{
    public class WishListDto
    {
        public string UserId { get; set; }
        public int whishlistId { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
