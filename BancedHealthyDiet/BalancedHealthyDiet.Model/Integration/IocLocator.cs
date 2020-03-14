using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Data.Repositories;
using BancedHealthyDiet.Models;
using BancedHealthyDiet.Model.Interfaces;
using DependencyInjectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalancedHealhtDiet.Data.Configuration;

namespace BalancedHealthyDiet.Model.Integration
{
    public  class IocLocator
    {
        private readonly IOC container;
        public IocLocator(IOC container)
        {
            this.container = container;
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<BalanceDietAppContext>();
            container.Register<IRecipeLogic, RecipesLogic>();
            container.Register<INutritionCalculator, NutririonCalculator>();
            container.Register<IGenericRepository<Recipe>, Repository<Recipe>>();
            container.Register<IGenericRepository<Ingredient>, Repository<Ingredient>>();
            container.Register<IGenericRepository<Nutrition>, Repository<Nutrition>>();
            container.Register<IGenericRepository<Product>, Repository<Product>>();
        }
    }
}
