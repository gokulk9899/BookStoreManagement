using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderByIdAsync(int userId);
        void AddToCart(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        void EditOrderQuantity(Order order);
        Task<Order> FindOrder(int orderId);
    }
}
