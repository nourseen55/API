using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.IReository;
using WebApplication1.Model;

namespace WebApplication1.Repository
{

    public class WishListReository:IWishListReository
    {
        private readonly AppDbContext context;
        public WishListReository(AppDbContext context)
        {
            this.context = context;
            
        }
        public WishList GetByUserId(string userId)
        {
            return context.WishLists.Include(w => w.WishlistItems)
                         .ThenInclude(i => i.Product)
                         .FirstOrDefault(w => w.UserId == userId);
        }
        public WishList GetByIdandUserId (string userId,int productid)
        {
            return context.WishLists.Include(w => w.WishlistItems).ThenInclude(i => i.Product).FirstOrDefault(u => u.UserId == userId);

        }
        public void Add(WishList item) {
            context.WishLists.Add(item);
             context.SaveChanges();

        }
        public void Update(WishList item) { context.WishLists.Update(item);context.SaveChanges(); }

    }
}
