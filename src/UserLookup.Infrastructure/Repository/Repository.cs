using UserLookup.Domain.Common;

namespace UserLookup.Infrastructure.Repository
{
    public abstract class Repository<T>
        where T : AggregateRoot
    {
        // If application grows big some common implementation can be moved here
    }
}
