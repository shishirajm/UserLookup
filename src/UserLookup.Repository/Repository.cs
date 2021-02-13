using System;
using UserLookup.Repository.DataProvider;

namespace UserLookup.Repository
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
