using Common.Core.DomainObjects;
using System;

namespace Common.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
