using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();
        public Order GetById(int id, string userid);
        public void DeleteById(int id);
        public void Update(Order order);
        public void Add(Order order);

    }
}
