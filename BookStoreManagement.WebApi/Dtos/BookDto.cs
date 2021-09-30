using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Dtos
{
    public class BookDto
    {
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
