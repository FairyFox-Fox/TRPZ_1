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

namespace BalancedHealthyDiet.Model.Integration
{
    public  class IocLocator
    {
        //private static void RegisterAutomapperDefault(IOC container, IEnumerable<Assembly> assemblies)
        //{
        //    AutoMapper.Mapper.Initialize(cfg =>
        //    {
        //        cfg.ConstructServicesUsing(container.Resolve);

        //        cfg.AddProfiles(assemblies);
        //    });
        //}
        private readonly IOC container;
        public IocLocator(IOC container)
        {

            this.container = container;
            //var mapper = AutoMapperConfiguration.ConfigureAutoMapper().CreateMapper();
            ////var mapper = new Mapper(AutoMapperConfiguration.ConfigureAutoMapper());
            //container.RegisterSingleton<MapperConfiguration>();
            //container.Register<IMapper, Mapper>();
            container.RegisterInstance<IMapper>(new Mapper(AutoMapperConfiguration.ConfigureAutoMapper()));

            //container.Register(AutoMapperConfiguration.ConfigureAutoMapper().CreateMapper()>
            //container.RegisterSingleton<MapperConfiguration>(config);
            //container.Register<IMapper>(AutoMapperConfiguration.ConfigureAutoMapper().CreateMapper().);
            container.Register<IUnitOfWork, UnitOfWork>();
            container.Register<BalanceDietAppContext>();
            container.Register<IRecipeLogic, RecipesLogic>();
            container.Register<INutritionCalculator, NutririonCalculator>();
            container.Register<IRecipeCategoryLogic, RecipeCategoryLogic>();
            container.Register<IGenericRepository<Recipe>, Repository<Recipe>>();
            container.Register<IGenericRepository<Ingredient>, Repository<Ingredient>>();
            container.Register<IGenericRepository<Nutrition>, Repository<Nutrition>>();
            container.Register<IGenericRepository<Product>, Repository<Product>>();
        }
    }
}
