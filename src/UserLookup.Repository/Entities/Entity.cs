using System;
namespace UserLookup.Repository.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }
    }
}
