using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;


        public PaymentController(IPaymentRepository paymentRepository, IHttpContextAccessor _contextAccessor,UserManager<ApplicationUser> userManager)
        {
            _paymentRepository = paymentRepository;
            this._contextAccessor = _contextAccessor;
            this._userManager = userManager;
        }

        [Authorize]
        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment(Payment payment)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            payment.UserId = user.Id;

            var processedPayment =  _paymentRepository.ProcessPaymentAsync(payment);
            return Ok(processedPayment);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public  IActionResult GetPaymentById(int id)
        {
            var payment =  _paymentRepository.GetPaymentByIdAsync(id);
            if (payment == null) return NotFound("Payment not found");
            return Ok(payment);
        }
    }
}
