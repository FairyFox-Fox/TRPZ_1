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

        public IEnumerable<RecipeDTO> GetRecipes()
        {
           // var mapper = new MapperConfiguration(config => config.CreateMap<Data.Entitites.Recipe, Recipe>()).CreateMapper();
            //return mapper.Map<IEnumerable< Data.Entitites.Recipe>,List<Recipe>>( dataset.Recipes.GetAll());
            //AUTOMAPPER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var recipes = dataset.Recipes.GetAll().Select(recipe=>new RecipeDTO(recipe.Id, recipe.ImagePath,recipe.RecipeName,recipe.Instruction,recipe.Ingredients.
                Select(ingred=>new IngredientDTO(ingred.Id,new ProductDTO(ingred.Product.Id,ingred.Product.ProductName,
                new NutritionDTO(ingred.Product.Nutrition.Id,ingred.Product.Nutrition.Calories, ingred.Product.Nutrition.Minerals, ingred.Product.Nutrition.Vitamins, ingred.Product.Nutrition.Fats
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
