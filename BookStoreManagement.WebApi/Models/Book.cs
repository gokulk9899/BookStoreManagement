using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Models
{
    public class Book
    {
        public int BookId { get; set; }
        
        public string BookTitle { get; set; }
        public string AuthorName{get;set;}
        public string Category { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public int? Rating { get; set; }
        public string Image { get; set; }
        public DateTime UploadTime { get; set; }

    }
}
