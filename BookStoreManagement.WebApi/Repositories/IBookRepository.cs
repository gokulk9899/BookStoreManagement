using BookStoreManagement.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBestSellerBooksAsync();
        Task<IEnumerable<Book>> GetTrendingBooksAsync();
        Task<IEnumerable<Book>> GetLatestBooksAsync();

        Task<IEnumerable<Book>> SearchRelatedBook(string bookAuthorName);
        void AddBook(Book book);
        Book GetBook(int id);

        
    }
}
