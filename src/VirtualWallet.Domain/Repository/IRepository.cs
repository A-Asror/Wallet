using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualWallet.Domain.Domain;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Specification;

namespace VirtualWallet.Domain.Repository;

public interface IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
{
    TEntity FindById(Guid id);
    Task<TEntity> FindOneAsync(ISpecification<TEntity> spec);
    Task<List<TEntity>> FindAsync(ISpecification<TEntity> spec);
    Task<TEntity> AddAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}

public interface IGridRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
{
    ValueTask<long> CountAsync(IGridSpecification<TEntity> spec);
    Task<List<TEntity>> FindAsync(IGridSpecification<TEntity> spec);
}
