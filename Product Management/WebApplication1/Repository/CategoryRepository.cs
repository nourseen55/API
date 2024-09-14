using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
            
        }
        public void Add(Category employee)
        {
            _context.Categories.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var emp= _context.Categories.FirstOrDefault(x=>x.Id==id);
            if (emp!=null) 
                {
                _context.Categories.Remove(emp);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, CategoryDto employee)
        {
           var emp=GetById(id);
            emp.Name = employee.Name;
            emp.Description = employee.Description;
            _context.Categories.Update(emp);
            _context.SaveChanges();
        }
    }
}
