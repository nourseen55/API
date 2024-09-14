using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Model;

namespace WebApplication1.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

      
    }
}
