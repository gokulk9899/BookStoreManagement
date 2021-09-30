using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public interface IUnitOfWork
    {
        IBookRepository bookRepository { get; }
        IOrderRepository orderRepository { get; }
        IUserRepository userRepository { get; }
        Task<bool> SaveAsync();
    }
}
