using BookTrader.Data.Repository;

namespace BookTrader.Data.Service
{
    /// <summary>
    /// TODO: when more complex logic move call of some method to service rather then selected repository
    /// </summary>
    public class BookTraderService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ITraderRepository _traderRepository;

        public BookTraderService(BookTraderContext context)
        {
            _bookRepository = new BookRepository(context);
            _traderRepository = new TraderRepository(context);
        }

        public BookTraderService(IBookRepository bookRepository, ITraderRepository traderRepository)
        {
            _bookRepository = bookRepository;
            _traderRepository = traderRepository;
        }
    }
}