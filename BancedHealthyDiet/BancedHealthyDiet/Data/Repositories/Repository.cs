using BancedHealthyDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BancedHealthyDiet.Data.Repositories
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BalanceDietAppContext appContext;

        public Repository(BalanceDietAppContext appContext)
        {
            this.appContext = appContext;
        }
        public TEntity Get(Guid id)
        {
            //return appContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
