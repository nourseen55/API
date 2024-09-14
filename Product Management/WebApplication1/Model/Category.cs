using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Product>? Products { get; set; }
    }
}
