using TestTask.Domain.Models;
using TestTask.Domain.Repositories;

namespace TestTask.WebApi.Services
{
    public class SingleOrderService : ISingleOrderService
    {
        private readonly IOrderRepository orderRepository;
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public SingleOrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<Order> GetSingleOrder()
        {
            var orders = await GetOrders();
            if (!orders.Any())
            {
                return new Order();
            }

            return orders.Single();
        }

        public async Task<bool> UpdateSingleOrder(Order order)
        {
            var orders = await GetOrders();
            if (orders.Any())
            {
                return await UpdateOrder(orders, order);
            }

            return await AddSingleOrder(order);
        }

        private async Task<List<Order>> GetOrders()
        {
            var orders = await orderRepository.GetOrdersAsync();

            if (orders.Count > 1)
            {
                throw new Exception("Database contains more than one order.");
            }

            return orders;
        }

        private async Task<bool> UpdateOrder(List<Order> orders, Order orderUpdated)
        {
            var orderDb = orders.Single();
            orderDb.Quantity = orderUpdated.Quantity;
            orderDb.Material = orderUpdated.Material;

            return await orderRepository.UpdateAsync(orderDb);
        }

        private async Task<bool> AddSingleOrder(Order order)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                var exists = await orderRepository.Any();
                if (exists)
                {
                    var orders = await GetOrders();
                    return await UpdateOrder(orders, order);
                }
                else
                {
                    return await orderRepository.AddAsync(order);
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
