using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAll();
        public Review GetById(int id);
        public Review GetByProductId(int proid);
        public void DeleteById(int id);
        public void Update(Review review);
        public void Add(Review review);

    }
}
