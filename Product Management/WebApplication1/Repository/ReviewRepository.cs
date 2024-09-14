using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _context;


        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public void  Add(Review Review)
        {

            _context.Reviews.Add(Review);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var rev= _context.Reviews.FirstOrDefault(x=>x.Id==id);
            if (rev != null) 
                {
                _context.Reviews.Remove(rev);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public Review GetById(int id)
        {
            return _context.Reviews.FirstOrDefault(x => x.Id == id);
        }

        public Review GetByProductId(int proid)
        {
            return _context.Reviews.FirstOrDefault(x=>x.ProductId==proid);
        }

        public void Update( Review Review)
        {

            _context.Entry(Review).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
