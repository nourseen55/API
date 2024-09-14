using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface IWishListReository
    {
        public void Add(WishList wishList);
        public WishList GetByIdandUserId(string userId, int productid);
        public void Update(WishList item);
        public WishList GetByUserId(string userId);

    }
}
