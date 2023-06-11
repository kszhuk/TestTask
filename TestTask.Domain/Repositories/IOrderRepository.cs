using TestTask.Domain.Models;

namespace TestTask.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<bool> AddAsync(Order entity);
        Task<bool> UpdateAsync(Order entity);
        Task<bool> Any();
    }
}
