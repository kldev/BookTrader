using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTrader.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BookTrader.Data.Repository
{
    public class TraderRepository : BaseRepository, ITraderRepository
    {
        public TraderRepository(BookTraderContext context) 
            : base(context)
        {
        }

        public async Task<List<Trader>> GetListAsync()
        {
            return await Context.Traders.ToListAsync();
        }
    }
}