using System;

namespace BookTrader.Data.Model
{
    public class Book
    {
        /// <summary>
        /// The book Id (GUID)
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The Trader Id (GUID) 
        /// </summary>
        public string TraderId { get; set; }
        
        /// <summary>
        /// The book Title
        /// </summary>
        public String Title { get; set; }
        
        /// <summary>
        /// The book author
        /// </summary>
        public String Author { get; set; }
        
        /// <summary>
        /// The sold book count
        /// </summary>
        public int SoldCount { get; set; }
        
        /// <summary>
        /// The price
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// The added book time
        /// </summary>
        public DateTime Added { get; set; }
        
        /// <summary>
        /// The book trader (EF)
        /// </summary>
        public Trader Trader { get; set; }
    }
}