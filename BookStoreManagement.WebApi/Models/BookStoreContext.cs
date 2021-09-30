using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Models
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

        public DbSet<User> UsersTbl { get; set; }
        public DbSet<Book> BooksTbl { get; set; }
        public DbSet<Order> OrdersTbl { get; set; }
       
    }
}
