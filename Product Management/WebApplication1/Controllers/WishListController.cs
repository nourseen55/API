using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishListController : ControllerBase
    {
        private readonly IWishListReository wishrepo;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _usermanager;
       

        public WishListController(IHttpContextAccessor _contextAccessor, UserManager<ApplicationUser> manager,IWishListReository wishListReository)
        {
            this._contextAccessor = _contextAccessor;
            this._usermanager = manager;
            this.wishrepo = wishListReository;
        }
        [HttpPost("add/{productId}")]

        public async Task<IActionResult> AddToWhishlistAsync(int productId)
        {
            ApplicationUser? user = await _usermanager.GetUserAsync(_contextAccessor.HttpContext.User);

            if (user == null)
            {
                throw new InvalidOperationException("User is not authenticated.");
            }
            WishList whishlist = wishrepo.GetByIdandUserId(user.Id, productId);

            if (whishlist == null)
            {
                whishlist = new WishList { UserId = user.Id };
                wishrepo.Add(whishlist);

                whishlist.WishlistItems.Add(new WishlistItem { ProductId = productId });
                wishrepo.Update(whishlist);
                return Ok(whishlist);
            }
            else
            {
                whishlist.WishlistItems.Add(new WishlistItem { ProductId = productId });
                wishrepo.Update(whishlist);
                return Ok(whishlist);
            }
        }
        [HttpDelete("remove/{productId}")]
        public async Task<IActionResult> RemoveFromWishlistAsync(int productId)
        {
            ApplicationUser? user = await _usermanager.GetUserAsync(_contextAccessor.HttpContext.User);

            if (user == null)
            {
                throw new InvalidOperationException("User is not authenticated.");
            }

            var whishlis = wishrepo.GetByIdandUserId(user.Id, productId);

            if (whishlis == null) { throw new Exception("No Whishlist!!"); }

            var item = whishlis?.WishlistItems?.FirstOrDefault(w => w.ProductId == productId);

            if (item != null)
            {
                whishlis?.WishlistItems?.Remove(item);
                wishrepo?.Update(whishlis);
                return Ok("Removed item from wishlist");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ApplicationUser? user = await _usermanager.GetUserAsync(_contextAccessor.HttpContext.User);

            if (user == null)
            {
                throw new InvalidOperationException("User is not authenticated.");
            }

            var whishlis = wishrepo.GetByUserId(user.Id);
            if (whishlis != null) {
                var pros = new List<Product>();
                foreach (var item in whishlis.WishlistItems)
                {
                    pros.Add(item.Product);
                    
                }
                WishListDto wishListDto = new WishListDto() { 
                    Products = pros ,
                    UserId=user.Id,
                    whishlistId=whishlis.Id};
                return Ok(whishlis);


            }
            return BadRequest();

        }


    }
}
