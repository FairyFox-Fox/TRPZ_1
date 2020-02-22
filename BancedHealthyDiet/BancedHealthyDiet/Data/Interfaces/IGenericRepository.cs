using System;
using System.Collections.Generic;
using System.Text;

namespace BancedHealthyDiet.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
    }
}
