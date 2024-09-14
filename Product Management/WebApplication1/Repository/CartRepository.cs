using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        public CartRepository(AppDbContext context) { 
            _context = context;
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public Cart GetCartByUserId(string userId)
        {
            return _context.Carts.Include(x => x.items).ThenInclude(x => x.Product).FirstOrDefault(x => x.userid == userId);
        }
      

        public void RemoveItemFromCart(string userid, int productid)
        {
            var cart =GetCartByUserId(userid);
            var item=cart.items.FirstOrDefault(x=>x.ProductId == productid);
            cart.items.Remove(item);
            UpdateCart(cart);
        }
  
        public void UpdateCart(Cart cart)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
        }
       
    }
}
