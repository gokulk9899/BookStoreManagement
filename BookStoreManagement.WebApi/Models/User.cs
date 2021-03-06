using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }

    }
}
