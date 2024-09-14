using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface ICartRepository
    {
        public Cart GetCartByUserId(string userId);
        public void CreateCart(Cart cart);
        public void UpdateCart(Cart cart);
        public void RemoveItemFromCart(string userid, int productid);

    }
}
