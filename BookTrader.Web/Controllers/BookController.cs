using System;
using System.Collections.Generic;
using BookTrader.Data.ApiModel;
using BookTrader.Data.Model;
using BookTrader.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookTrader.Web.Controllers
{
    /// <summary>
    ///  TODO: This controller should be access only by authenicated trader
    /// </summary>
    [Route("/api/book")]
    [ApiController]
    public class BookController
    {
        private IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        [HttpPost]
        [Route("/api/book/list")]
        public ApiResponse<List<Book>> GetAll(GetAllBookRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Id)) return new ApiResponse<List<Book>>(ErrorResponse.InvalidParams);

            List<Book> books = _bookRepository.traderBooks(request.Id, request.Title, request.Author);
            
            return new ApiResponse<List<Book>>(books);
        }

        [HttpPost]
        [Route("/api/book/add")]
        public ApiResponse<MessageResponse> AddBook(AddBook request)
        {
            if (request == null ) return new ApiResponse<MessageResponse>(ErrorResponse.InvalidParams);
            
            // TODO: this logic can be part of service not controller
            
            if (string.IsNullOrWhiteSpace(request.Title)) return new ApiResponse<MessageResponse>(ErrorResponse.fieldCanNotBeNullOrEmpty("title"));
            
            if (string.IsNullOrWhiteSpace(request.Author)) return new ApiResponse<MessageResponse>(ErrorResponse.fieldCanNotBeNullOrEmpty("author"));
            
            if (string.IsNullOrWhiteSpace(request.TraderId)) return new ApiResponse<MessageResponse>(ErrorResponse.fieldCanNotBeNullOrEmpty("traderId"));
                        
            if (request.Price <= 0) return new ApiResponse<MessageResponse>(ErrorResponse.PriceCanNotBeLessThenZero);

            String id = _bookRepository.Add(new Book() { Id = Guid.NewGuid().ToString("N"), TraderId =  request.TraderId, Added = DateTime.Now, Title = request.Title, Author = request.Author, Price = request.Price, SoldCount = 0});
            
            return new ApiResponse<MessageResponse>(new MessageResponse(){ Message = "Book added with ID: " + id});
        }
        
        [HttpPost]
        [Route("/api/book/single")]
        public ApiResponse<Book> GetBook(IdRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Id)) return new ApiResponse<Book>(ErrorResponse.InvalidParams);

            Book book = _bookRepository.GetOne(request.Id);
            
            if (book == null) return new ApiResponse<Book>(ErrorResponse.NotFound);
            
            return new ApiResponse<Book>(book);
        }
    }
}