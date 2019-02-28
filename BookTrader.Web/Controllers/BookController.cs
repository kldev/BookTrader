using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookTrader.Data.ApiModel;
using BookTrader.Data.Model;
using BookTrader.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookTrader.Web.Controllers
{
    /// <summary>
    ///  TODO: This controller should be access only by authenticated trader
    /// </summary>
    [Route("/api/book")]
    [ApiController]
    public class BookController
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        
        [HttpPost]
        [Route("/api/book/list")]
        public async Task<ApiResponse<List<Book>>> GetAll(GetAllBookRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Id)) return new ApiResponse<List<Book>>(ErrorResponse.InvalidParams);

            var books = await _bookRepository.TraderBooksAsync(request.Id, request.Title, request.Author);
            
            return new ApiResponse<List<Book>>(books);
        }

        [HttpPost]
        [Route("/api/book/add")]
        public async Task<ApiResponse<MessageResponse>> AddBook(AddBook request)
        {
            if (request == null) return new ApiResponse<MessageResponse>(ErrorResponse.InvalidParams);

            // TODO: this logic can be part of service not controller

            if (string.IsNullOrWhiteSpace(request.Title))
                return new ApiResponse<MessageResponse>(ErrorResponse.FieldCanNotBeNullOrEmpty("title"));

            if (string.IsNullOrWhiteSpace(request.Author))
                return new ApiResponse<MessageResponse>(ErrorResponse.FieldCanNotBeNullOrEmpty("author"));

            if (string.IsNullOrWhiteSpace(request.TraderId))
                return new ApiResponse<MessageResponse>(ErrorResponse.FieldCanNotBeNullOrEmpty("traderId"));

            if (request.Price <= 0) return new ApiResponse<MessageResponse>(ErrorResponse.PriceCanNotBeLessThenZero);

            var id = await _bookRepository.AddAsync(new Book
            {
                Id = Guid.NewGuid().ToString("N"),
                TraderId = request.TraderId,
                Added = DateTime.Now, 
                Title = request.Title, 
                Author = request.Author,
                Price = request.Price, 
                SoldCount = 0
            });

            return new ApiResponse<MessageResponse>(new MessageResponse() {Message = "Book added with ID: " + id});
        }

        [HttpPost]
        [Route("/api/book/single")]
        public async Task<ApiResponse<Book>> GetBook(IdRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Id)) return new ApiResponse<Book>(ErrorResponse.InvalidParams);

            var book = await _bookRepository.GetAsync(request.Id);
            
            if (book == null) return new ApiResponse<Book>(ErrorResponse.NotFound);
            
            return new ApiResponse<Book>(book);
        }
    }
}