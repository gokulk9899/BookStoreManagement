using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);     
        void UpdateUser(User user);
        User Register(string userName, string password);
        Task<bool> UserAlreadyRegistered(string userName);
        Task<User> Authenticate(string userName, string password);
    }
}
