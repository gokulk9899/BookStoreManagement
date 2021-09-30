using AutoMapper;
using BookStoreManagement.WebApi.Dtos;
using BookStoreManagement.WebApi.Models;
using BookStoreManagement.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
