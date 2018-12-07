using System;

namespace BookTrader.Data.ApiModel
{
    public class GetAllBookRequest : IdRequest
    {
        public String Title { get; set; }
        public String Author { get; set; }
    }
}