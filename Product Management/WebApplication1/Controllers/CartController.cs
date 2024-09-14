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
    public class CartController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICartRepository _cartRepository;


        public CartController(IProductRepository productRepository, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor,ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            this.userManager = userManager; 
            _contextAccessor = httpContextAccessor;
            _cartRepository = cartRepository;

            
        }
        [HttpGet]
        public async Task<IActionResult> GetCart() {
            ApplicationUser user = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var cart = _cartRepository.GetCartByUserId(user.Id);
            return Ok(cart);

        }
        [HttpPost("addtocart")]
        public  async Task<IActionResult> AddToCart(ItemDto itemDto)
        {
            var product =_productRepository.GetById(itemDto.ProductId);
            if (product == null) {
                return NotFound();
            
            }
            ApplicationUser user = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            var cart = _cartRepository.GetCartByUserId(user.Id);
            if (cart==null)
            {
                cart = new Cart()
                {
                    userid = user.Id,
                };
                _cartRepository.CreateCart(cart);
                
            }
            var item = cart.items.FirstOrDefault(x => x.ProductId == product.Id);
            if (item == null) {
                cart.items.Add( new CartItem()
                {
                    Product = product,
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity
                });
            }
            else
            {
                item.Quantity += itemDto.Quantity;
            }
            _cartRepository.UpdateCart(cart);
            return Ok(new
            {
                Message = "Added To Cart",
                TotalPrice = cart.TotalPrice
            });


        }
        [HttpDelete("RemoveItem/{productid}")]
        public async Task<IActionResult> RemoveItemFromCart(int productid)
        {
            var user = await userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            _cartRepository.RemoveItemFromCart(user.Id, productid);
            return Ok("Item Removed From Cart");
        }
      


    }
}
