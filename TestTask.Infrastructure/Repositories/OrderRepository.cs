using TestTask.Domain.Repositories;
using TestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TestTask.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public OrderRepository(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(Order order)
        {
            var dbOrder = mapper.Map<Order, DataModels.Order>(order);
            await dataContext.AddAsync(dbOrder);

            var created = await dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> Any()
        {
            return await dataContext.Orders.AnyAsync();
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var dbOrders = await dataContext.Orders.AsNoTracking().ToListAsync();

            var orders = mapper.Map<List<DataModels.Order>, List<Order>>(dbOrders);
            return orders;
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            var dbOrder = mapper.Map<Order, DataModels.Order>(order);
            dataContext.Update(dbOrder);

            var updated = await dataContext.SaveChangesAsync();
            return updated > 0;
        }
    }
}
