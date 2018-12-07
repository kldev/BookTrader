using System;

namespace BookTrader.Data.ApiModel
{
    public class AddBook 
    {
        public string TraderId { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public decimal Price { get; set; }
    }
}