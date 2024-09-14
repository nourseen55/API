using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartRepository cartRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository, IHttpContextAccessor _contextAccessor,UserManager<ApplicationUser> manager)
        {
            this.orderRepository = orderRepository;
            this._contextAccessor = _contextAccessor;
            this._userManager = manager;
            this.cartRepository = cartRepository;
        }
        [HttpGet]
        public IActionResult Getpro()
        {
            var emps=orderRepository.GetAll();
            return Ok(emps);

        }
        [HttpGet("order/{id:int}", Name = "GetOrderById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userManager.GetUserAsync( _contextAccessor.HttpContext.User);
            var emp = orderRepository.GetById(id,user.Id);
            return Ok(emp);

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Add(OrderDto pro)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
                var cart = cartRepository.GetCartByUserId(user.Id);
                var item = cart.items.FirstOrDefault(x => x.ProductId == pro.ProductId);

                if (item == null)
                {
                    return BadRequest("Product not found in cart.");
                }
                Order order = new Order
                {
                    Address = pro.Address,
                    OrderDate = pro.OrderDate,
                    Status = "Pending",
                    UserId = user.Id,
                    ProductId = pro.ProductId,
                    ProductName = item.Product.Name 
                };
                order.UpdateQuantity(item.Quantity);
                order.CalculateTotalPrice(item.Product.Price);

                orderRepository.Add(order);
                var link = Url.Link("GetOrderById", new { id = pro.Id });
                return Created(link, pro);
            }
            return BadRequest();
        }
        [Authorize(Roles = "Admin")]

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDto orderDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
                if (user == null)
                {
                    return Unauthorized(); 
                }

                var order = orderRepository.GetById(id, user.Id);
                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }
                if (order.UserId != user.Id)
                {
                    return Forbid(); 
                }

                if (order.IsPendingOrder())
                {
                    order.Address = orderDto.Address ?? order.Address;
                    order.Status = orderDto.Status ?? order.Status; 
                    order.OrderDate = orderDto.OrderDate != DateTime.MinValue ? orderDto.OrderDate : order.OrderDate;

                    orderRepository.Update(order);
                    cartRepository.RemoveItemFromCart(user.Id, orderDto.ProductId);
                    return Ok(order); 
                }
                else
                {
                    return BadRequest("Order cannot be updated because it is not in 'Pending' status.");
                }
            }

            return BadRequest(ModelState); 
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteById(int id)
        {
            orderRepository.DeleteById(id);
            return StatusCode(204);
        }

      

    }
}
