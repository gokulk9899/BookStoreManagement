using AutoMapper;
using BookStoreManagement.WebApi.Custom_Exceptions;
using BookStoreManagement.WebApi.Dtos;
using BookStoreManagement.WebApi.Models;
using BookStoreManagement.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitWork;
        private readonly IMapper mapper;


        public BookController(IUnitOfWork unitWork,IMapper mapper)
        {
            this.unitWork = unitWork;
            this.mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet("GetBestSellerBooks")]
        public async Task<IActionResult> GetBestSellerBooks()
        {
            var books = await unitWork.bookRepository.GetBestSellerBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetTrendingBooks")]
        public async Task<IActionResult> GetTrendingBooks()
        {
            var books = await unitWork.bookRepository.GetTrendingBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetLatestBooks")]
        public async Task<IActionResult> GetLatestBooks()
        {
            var books = await unitWork.bookRepository.GetLatestBooksAsync();
            return Ok(books);
        }

        
        // GET api/<BookController>/5
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            if (id == 0) {
                throw new InvalidBookIdException(id);
            }
            var book = await Task.FromResult(unitWork.bookRepository.GetBook(id));
            if (book is null) {
                return NotFound();
            }
            return Ok(book);
                       
        }

        [HttpGet("SearchBooks/{id}")]
        public async Task<IActionResult> SearchBooks(int id)
        {
            if (id == 0)
            {
                throw new InvalidBookIdException(id);
            }
            var book = await Task.FromResult(unitWork.bookRepository.GetBook(id));
            if (book is null)
            {
                return NotFound();
            }
            return Ok(book);

        }


        // POST api/<BookController>
        [HttpPost("Upload")]
        [Authorize]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var book = mapper.Map<Book>(bookDto);
            book.UploadTime = DateTime.Now;
            unitWork.bookRepository.AddBook(book);
            await unitWork.SaveAsync();
            return StatusCode(201);
        }
    }
}
