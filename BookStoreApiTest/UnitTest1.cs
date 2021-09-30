using AutoMapper;
using BookStoreManagement.WebApi.Controllers;
using BookStoreManagement.WebApi.Dtos;
using BookStoreManagement.WebApi.Models;
using BookStoreManagement.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace BookStoreApiTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<IUnitOfWork> mockUnitWork = new Mock<IUnitOfWork>();
        private readonly Mock<IMapper> mockMapper = new Mock<IMapper>();
        [TestMethod]
        public void GetBookByIdTest()
        {
            //Arrange
            Book book = new Book()
            {
                BookId=1,
                BookTitle = "harrypotter",
                AuthorName = "jk rowling",
                Category = "fiction",
                Details = "good bbok",
                Price = 120,
                Image = "image.jpg",
                Rating=4,
                UploadTime= DateTime.Now


            };


            mockUnitWork.Setup(x => x.bookRepository.GetBook(1)).Returns(book);
            BookController controller = new BookController(mockUnitWork.Object, mockMapper.Object);


            //Act
            var result = controller.GetBook(1).Result as OkObjectResult;


            //Assert
            Assert.AreEqual(book.BookId, (result.Value as Book).BookId);
        }

        [TestMethod]
        public void GetMethodShouldReturnNotFound() {
            //Arrange
            BookController controller = new BookController(mockUnitWork.Object, mockMapper.Object);

            //Act

            var result = controller.GetBook(1).Result;
            
            //Assert

            Assert.IsFalse(result is NotFoundObjectResult);
        }
    }
}
