﻿using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BancedHealthyDiet.Models;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Model.Interfaces;

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
            var recipes = dataset.Recipes.GetAll().Select(recipe=>new RecipeDTO(recipe.Id, recipe.Images.FirstOrDefault().ImagePath,recipe.RecipeName,recipe.ShortDescription,recipe.Ingredients.
                Select(ingred=>new IngredientDTO(ingred.Id,new ProductDTO(ingred.Products.FirstOrDefault().Id, ingred.Products.FirstOrDefault().ProductName,
                new NutritionDTO(ingred.Products.FirstOrDefault().Nutrition.Id, ingred.Products.FirstOrDefault().Nutrition.Calories, ingred.Products.FirstOrDefault().Nutrition.Minerals, ingred.Products.FirstOrDefault().Nutrition.Vitamins, ingred.Products.FirstOrDefault().Nutrition.Fats
                , ingred.Products.FirstOrDefault().Nutrition.Carbonhydrates, ingred.Products.FirstOrDefault().Nutrition.Proteins))
                , ingred.Weight,ingred.MeasurementUnit)).ToList()));
            return recipes;
        }
        public void Dispose()
        {
            dataset.Dispose();
        }

       
    }
}
