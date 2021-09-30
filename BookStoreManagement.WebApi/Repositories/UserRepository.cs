using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext context;

        public UserRepository(BookStoreContext context)
        {
            this.context = context;
        }
        public void AddUser(User user)
        {
            context.UsersTbl.Add(user);
        }

        public async Task<User> Authenticate(string userName, string passwordText)
        {
            var user = await Task.FromResult(context.UsersTbl.FirstOrDefault(x =>x.UserName == userName));
            if (user == null) {
                return null;
            }
            if (!MatchPasswordHash(passwordText, user.Password, user.PasswordKey)) {
                return null;
            }
            return user;
        }

        private bool MatchPasswordHash(string passwordText, byte[] password, byte[] passwordKey)
        {
            using (var hmac = new HMACSHA512(passwordKey))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordText));

                for (int i = 0; i < passwordHash.Length; i++) {
                    if (passwordHash[i] != password[i]) {
                        return false;
                    }
                }

            }
            return true;

        }

       

        public User Register(string userName, string password)
        {
            byte[] passwordHash, passwordKey;
            using (var hmac = new HMACSHA512()) {
                passwordKey = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            User user = new User();
            user.UserName = userName;
            user.Password = passwordHash;
            user.PasswordKey = passwordKey;

            return user;

        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserAlreadyRegistered(string userName)
        {
            return await Task.FromResult(context.UsersTbl.Any(x => x.UserName == userName));
        }
    }
}
