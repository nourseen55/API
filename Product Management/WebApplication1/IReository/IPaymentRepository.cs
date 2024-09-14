using WebApplication1.Model;

namespace WebApplication1.IReository
{
    public interface IPaymentRepository
    {
        Payment GetPaymentByIdAsync(int id);
        Payment ProcessPaymentAsync(Payment payment);
    }
}
