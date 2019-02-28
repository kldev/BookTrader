using System;
using System.Collections.Generic;
using BookTrader.Data;
using BookTrader.Data.Model;
using BookTrader.Data.Repository;
using BookTrader.Data.Util;
using Faker;
using Xunit;

namespace BookTrader.Test.Repository
{
    
    public class TraderRepositoryTests
    {
        private readonly TraderRepository _traderRepository = new TraderRepository(new BookTraderContext(TestHelper.TEST_CONNECTION_STRING));
       
        [Fact]
        public void CanReturnTraders()
        {
            TestHelper.SetupTestDb();

            using (var context = new BookTraderContext(TestHelper.TEST_CONNECTION_STRING))
            {
                context.Traders.Add(createRandomTrader());
                context.Traders.Add(createRandomTrader());
                context.Traders.Add(createRandomTrader());
                context.Traders.Add(createRandomTrader());
                context.Traders.Add(createRandomTrader());

                context.SaveChanges();
            }

            List<Trader> list = _traderRepository.GetListAsync().Result;
            
            Assert.True(list.Count == 5);

        }

        [Fact]
        public void CanSeedDatabase()
        {
            TestHelper.SetupTestDb();
            
            DatabaseSeedUtil.SeedData();
            
            List<Trader> list = _traderRepository.GetListAsync().Result;
            
            Assert.True(list.Count == 1);
        }

        private Trader createRandomTrader()
        {
            return new Trader()
            {
                Id = Guid.NewGuid().ToString("N"),
                Lastname = Name.Last(),
                Name = Name.First(),
                Password = RandomNumber.Next().ToString(),EMail = $"{Name.First().ToLower()}@ygmail.com"
            };
        }
    }
}