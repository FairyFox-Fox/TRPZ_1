using BancedHealthyDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BancedHealthyDiet.Data.Repositories
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class,IEntity,new()
    {
        private readonly BalanceDietAppContext appContext;
        DbSet<TEntity> dbSet;

        public Repository(BalanceDietAppContext appContext)
        {
            // this.appContext = appContext;
            this.appContext = new BalanceDietAppContext();
            dbSet = appContext.Set<TEntity>();
        }
        public TEntity Get(Guid id)
        {
            //return appContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
            return GetAll().FirstOrDefault(entity => entity.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return appContext.Set<TEntity>();
        }
    }
}
