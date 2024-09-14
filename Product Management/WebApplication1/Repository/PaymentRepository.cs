using Microsoft.AspNetCore.Identity;
using WebApplication1.Data;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public PaymentRepository(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public Payment GetPaymentByIdAsync(int id)
        {
            return  _context.Payments.Find(id);
        }

        public Payment ProcessPaymentAsync(Payment payment)
        {
           
             _context.Payments.Add(payment);
             _context.SaveChanges();
            return payment;
        }
    }
}
