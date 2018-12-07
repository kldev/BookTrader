using System.Collections.Generic;
using BookTrader.Data.ApiModel;
using BookTrader.Data.Model;
using BookTrader.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookTrader.Web.Controllers
{
    [Route("/api/trader/[action]")]
    [ApiController]
    public class TraderController
    {
        private ITraderRepository _traderRepository;
        
        public TraderController(ITraderRepository repository)
        {
            _traderRepository = repository;
        }
        
        [HttpGet]
        [Route("/api/trader/list")]
        public ApiResponse<List<Trader>> GetAll()
        {
            List<Trader> traders = _traderRepository.GetAll();
            
            return new ApiResponse<List<Trader>>(traders);
        }
    }
}