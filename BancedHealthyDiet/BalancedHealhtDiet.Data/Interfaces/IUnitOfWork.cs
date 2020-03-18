
using BalancedHealhtDiet.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Recipe> Recipes { get; }
        IGenericRepository<Ingredient> Ingredients { get; }
        IGenericRepository<Nutrition> Nutritions { get; }
        IGenericRepository<Product> Products { get;}
        IGenericRepository<Category> Categories { get; }
        void Save();
        void Rollback();
        void CreateTransaction();
        void Commit();

    }
}
