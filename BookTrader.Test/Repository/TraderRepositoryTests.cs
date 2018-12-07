using System;
using System.Collections.Generic;
using BookTrader.Data;
using BookTrader.Data.Model;
using BookTrader.Data.Repository;
using BookTrader.Data.Util;
using Xunit;

namespace BookTrader.Test.Repository
{
    
    public class TraderRepositoryTests
    {
        private readonly TraderRepository _traderRepository = new TraderRepository();
       
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

            List<Trader> list = _traderRepository.GetAll();
            
            Assert.True(list.Count == 5);

        }

        [Fact]
        public void CanSeedDatabase()
        {
            TestHelper.SetupTestDb();
            
            DatabaseSeedUtil.SeedData();
            
            List<Trader> list = _traderRepository.GetAll();
            
            Assert.True(list.Count == 1);
        }

        private Trader createRandomTrader()
        {
            return new Trader()
            {
                Id = Guid.NewGuid().ToString("N"),
                Lastname = Faker.Name.Last(),
                Name = Faker.Name.First(),
                Password = Faker.RandomNumber.Next().ToString(),EMail = $"{Faker.Name.First().ToLower()}@ygmail.com"
            };
        }
    }
}