using AutoMapper;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancedHealthyDiet.Models.Interfaces;

namespace BancedHealthyDiet.Models
{
    public  class RecipesLogic:IRecipeLogic
    {
        IUnitOfWork dataset;
        public RecipesLogic(IUnitOfWork dataset)
        {
            //this
            this.dataset = dataset;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
           // var mapper = new MapperConfiguration(config => config.CreateMap<Data.Entitites.Recipe, Recipe>()).CreateMapper();
            //return mapper.Map<IEnumerable< Data.Entitites.Recipe>,List<Recipe>>( dataset.Recipes.GetAll());
            var recipes = dataset.Recipes.GetAll().Select(recipe=>new Recipe(recipe.Id, recipe.ImagePath,recipe.RecipeName,recipe.Instruction,recipe.Ingredients.
                Select(ingred=>new Ingredient(ingred.Id,new Product(ingred.Product.Id,ingred.Product.ProductName,
                new Nutrition(ingred.Product.Nutrition.Id,ingred.Product.Nutrition.Calories, ingred.Product.Nutrition.Minerals, ingred.Product.Nutrition.Vitamins, ingred.Product.Nutrition.Fats
                , ingred.Product.Nutrition.Carbonhydrates, ingred.Product.Nutrition.Proteins))
                , ingred.Weight,ingred.MeasurementUnit)).ToList()));
            return recipes;
        }
        public void Dispose()
        {
            dataset.Dispose();
        }
    }
}
