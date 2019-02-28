namespace BookTrader.Data.Repository
{
    public abstract  class BaseRepository
    {
        protected readonly BookTraderContext Context;

        protected BaseRepository(BookTraderContext context)
        {
            Context = context;
        }
    }
}