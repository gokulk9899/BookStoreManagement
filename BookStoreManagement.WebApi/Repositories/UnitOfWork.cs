using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext context;

        public UnitOfWork(BookStoreContext context)
        {
            this.context = context;
        }
        public IBookRepository bookRepository => new BookRepository(context);

        public IOrderRepository orderRepository => new OrderRepository(context);

        public IUserRepository userRepository => new UserRepository(context);

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
