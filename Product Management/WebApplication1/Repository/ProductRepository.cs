using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public void Add(ProductDto employee)
        {
            Product product = new Product();
            product.Name = employee.Name;
            product.Description = employee.Description;
            product.Price = employee.Price;
            product.CategoryId = employee.CategoryId;
            
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var emp= _context.Products.FirstOrDefault(x=>x.Id==id);
            if (emp!=null) 
                {
                _context.Products.Remove(emp);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(x=>x.Category).ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Include(x=>x.Category).FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, ProductDto employee)
        {
           Product emp=GetById(id);
            ProductDto productdto = new ProductDto();
            emp.Name = employee.Name;
            emp.Description = employee.Description;
            emp.Price = employee.Price;
            emp.CategoryId=employee.CategoryId;
            _context.Products.Update(emp);
            _context.SaveChanges();
        }
    }
}
