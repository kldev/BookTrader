using System.Collections.Generic;
using System.Threading.Tasks;
using BookTrader.Data.Model;

namespace BookTrader.Data.Repository
{
    public interface ITraderRepository
    {
        Task<List<Trader>> GetListAsync();
    }
}