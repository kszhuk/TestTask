using TestTask.Domain.Models;

namespace TestTask.WebApi.Services
{
    public interface ISingleOrderService
    {
        Task<Order> GetSingleOrder();
        Task<bool> UpdateSingleOrder(Order order);
    }
}
