using BookStoreManagement.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;

        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.BooksTbl.Add(book);
        }

        public Book GetBook(int id)
        {
            var book = context.BooksTbl.FirstOrDefault(x=>x.BookId==id);
            return book;
        }



        public async Task<IEnumerable<Book>> GetBestSellerBooksAsync()
        {
            return await Task.FromResult(context.BooksTbl.OrderBy(o=>o.Price).ToList());
        }

        public async Task<IEnumerable<Book>> GetTrendingBooksAsync()
        {
            return await Task.FromResult(context.BooksTbl.OrderByDescending(o => o.Rating).ToList());
        }

        public async Task<IEnumerable<Book>> GetLatestBooksAsync()
        {
            return await Task.FromResult(context.BooksTbl.OrderByDescending(o => o.UploadTime).ToList());
        }

        public async Task<IEnumerable<Book>> SearchRelatedBook(string bookAuthorName)
        {
            return await (context.BooksTbl.Where(x => x.BookTitle == bookAuthorName||x.AuthorName==bookAuthorName)).ToListAsync();
       
        }
    }
}
