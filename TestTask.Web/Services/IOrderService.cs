using TestTask.Web.Models;

namespace TestTask.Web.Services
{
    public interface IOrderService
    {
        Task<OrderModel> GetSingleOrder();
        Task<OrderModel> UpdateSingleOrder(OrderModel order);
    }
}
