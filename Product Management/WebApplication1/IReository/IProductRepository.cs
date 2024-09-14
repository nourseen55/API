using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product GetById(int id);
        public void DeleteById(int id);
        public void Update(int id, ProductDto employee);
        public void Add(ProductDto employee);

    }
}
