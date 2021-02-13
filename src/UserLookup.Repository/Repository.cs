using System;
using UserLookup.Infrastructure.DataProvider;

namespace UserLookup.Infrastructure
{
    public abstract class Repository<T>
    {
        //public T GetById(long id)
        //{
        //    using (IDataProvider provider = DataProviderFactory.GetProvider("HTTP"))
        //    {
        //        return provider.QueryData<T>();
        //    }
        //}
    }
}
