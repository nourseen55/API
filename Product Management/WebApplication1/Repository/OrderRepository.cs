using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderRepository(AppDbContext context,UserManager<ApplicationUser> userManager,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = httpContextAccessor;
            
        }
        public void  Add(Order order)
        {
            var user = _userManager.GetUserId(_contextAccessor.HttpContext.User);

            order.UserId = user;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var emp= _context.Orders.FirstOrDefault(x=>x.Id==id);
            if (emp!=null) 
                {
                _context.Orders.Remove(emp);
                _context.SaveChanges();
            }

        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id,string userid)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == id && x.UserId == userid);
        }

       

        public void Update( Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
