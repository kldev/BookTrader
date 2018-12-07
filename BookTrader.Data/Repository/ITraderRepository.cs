using System.Collections.Generic;
using BookTrader.Data.Model;

namespace BookTrader.Data.Repository
{
    public interface ITraderRepository
    {
        List<Trader> GetAll();
    }
}