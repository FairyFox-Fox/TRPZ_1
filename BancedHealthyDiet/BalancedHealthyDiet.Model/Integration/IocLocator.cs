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
using AutoMapper;
using BalancedHealthyDiet.Model.Interfaces;

namespace BalancedHealthyDiet.Model.Integration
{
    public  class IocLocator
    {
        private readonly IContainer container;
        public IocLocator(IContainer container)
        {

            this.container = container;
            container.RegisterInstance<IMapper>(new Mapper(AutoMapperConfiguration.ConfigureAutoMapper()));
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<BalanceDietAppContext>();
            container.Register<IRecipeLogic, RecipesLogic>();
            container.Register<INutritionCalculator, NutririonCalculator>();
            container.Register<IRecipeCategoryLogic, RecipeCategoryLogic>();
            container.Register<IGenericRepository<Recipe>, Repository<Recipe>>();
            container.Register<IGenericRepository<Ingredient>, Repository<Ingredient>>();
            container.Register<IGenericRepository<Nutrition>, Repository<Nutrition>>();
            container.Register<IGenericRepository<Product>, Repository<Product>>();
            container.Register<WebProductParser>();
            WebProductParser webProductParser = container.Resolve<WebProductParser>();
            //webProductParser.ParseTablesOfProduct();
            container.Register<IProductWithNutritionLIogic, ProductWithNutritionLogic>();
        }
    }
}
