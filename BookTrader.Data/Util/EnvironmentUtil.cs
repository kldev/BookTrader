using System;

namespace BookTrader.Data.Util
{
    public static class EnvironmentUtil
    {
        public static string GetEnv(string name)
        {
            return Environment.GetEnvironmentVariable(name) ?? string.Empty;
        }
    }
}