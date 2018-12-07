using System.Collections.Generic;
using System.Linq;
using BookTrader.Data.Model;

namespace BookTrader.Data.Repository
{
    public class TraderRepository : ITraderRepository
    {
        public List<Trader> GetAll()
        {
            using (var context = new BookTraderContext())
            {
                return context.Traders.ToList();
            }
        }
    }
}