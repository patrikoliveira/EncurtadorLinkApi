using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncurtadorLinkApi.Domain.Repositories
{
    public interface IDatabaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(Guid id);
    }
}