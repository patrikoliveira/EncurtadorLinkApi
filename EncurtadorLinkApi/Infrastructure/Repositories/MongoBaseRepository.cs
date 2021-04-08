using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EncurtadorLinkApi.Domain.Repositories;
using MongoDB.Driver;
using ServiceStack;

namespace EncurtadorLinkApi.Infrastructure.Repositories
{
    public abstract class MongoBaseRepository<TEntity> : IDatabaseRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected MongoBaseRepository(IMongoContext context)
        {
            Context = context;

            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Add(TEntity entity) => 
            Context.AddCommand(() => DbSet.InsertOneAsync(entity));

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);

            return all.ToList();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual void Remove(Guid id) =>
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));

        public virtual void Update(TEntity entity) =>
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.GetId()), entity));

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}