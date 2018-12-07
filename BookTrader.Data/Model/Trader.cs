using System;
using System.Collections.Generic;

namespace BookTrader.Data.Model
{
    public class Trader
    {
        public Trader()
        {
            BookList = new List<Book>();
        }
        
        /// <summary>
        /// The Trader Id (GUID) 
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// The firstname
        /// </summary>
        public String Name { get; set; }
        
        /// <summary>
        /// The lastname
        /// </summary>
        public String Lastname { get; set; }

        /// <summary>
        /// The email
        /// </summary>
        public String EMail { get; set; }
        
        /// <summary>
        /// The password (BCrypt hash)
        /// </summary>
        public String Password { get; set; }
        
        /// <summary>
        /// The trader book list (EF)
        /// </summary>
        public List<Book> BookList { get; set; }
               
    }
}