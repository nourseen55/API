using WebApplication1.Dto;
using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
        public Category GetById(int id);
        public void DeleteById(int id);
        public void Update(int id, CategoryDto Category);
        public void Add(Category Category);

    }
}
