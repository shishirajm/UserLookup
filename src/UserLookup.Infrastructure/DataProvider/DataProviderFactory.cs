using System;

namespace UserLookup.Infrastructure.DataProvider
{
    public static class DataProviderFactory
    {
        public static IDataProvider GetProvider(string type)
        {
            // We can add more data source providers
            if (type.ToUpper() == "HTTP")
            {
                return new HttpDataProvider();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
