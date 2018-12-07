using System;
using BookTrader.Data;
using BookTrader.Data.Util;
using Microsoft.EntityFrameworkCore;

namespace BookTrader.Test
{
    public static class TestHelper
    {

        public static readonly String TEST_CONNECTION_STRING =
            "Host=localhost;Database=booktest;Username=postgrestest;Password=postgrestest;Port=15432";

        public static void SetupTestDb()
        {
            Environment.SetEnvironmentVariable("WEB_DB_CONN", TEST_CONNECTION_STRING);
            using (var context = new BookTraderContext(TEST_CONNECTION_STRING))
            {
                context.Database.Migrate();

                DatabaseSeedUtil.DropData(TEST_CONNECTION_STRING);
            }
        }
    }


}