using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreContext context;

        public OrderRepository(BookStoreContext context)
        {
            this.context = context;
        }
        public void AddToCart(Order order)
        {
            var exitsOrder = context.OrdersTbl.FirstOrDefault(x => x.UserId == order.UserId && x.BookId == order.BookId);
            if (exitsOrder is null){
                order.Quantity = 1;
                context.OrdersTbl.Add(order);
            }
            else {
                exitsOrder.Quantity += 1;
                context.OrdersTbl.Update(exitsOrder);
            }
        }

        public void DeleteOrder(Order order)
        {
            context.OrdersTbl.Remove(order);
            context.SaveChanges();
        }

        public void EditOrderQuantity(Order order)
        {
            context.OrdersTbl.Update(order);
        }

        public async Task<Order> FindOrder(int orderId)
        {
            return await context.OrdersTbl.FindAsync(orderId);
        }

        public async  Task<IEnumerable<Order>> GetOrderByIdAsync(int userId)
        {
            return await Task.FromResult(context.OrdersTbl.ToList().Where(x => x.UserId == userId));
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
