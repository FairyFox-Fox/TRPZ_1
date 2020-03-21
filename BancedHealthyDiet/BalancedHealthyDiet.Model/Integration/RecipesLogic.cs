using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BancedHealthyDiet.Models;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Model.Interfaces;
using BalancedHealthyDiet.Model.Integration;
using BalancedHealhtDiet.Data.Entitites;
using Serilog;

namespace BalancedHealthyDiet.Model.Integration
{
    public  class RecipesLogic:IRecipeLogic
    {
        IUnitOfWork dataset;
        IMapper mapper;
        public RecipesLogic(IUnitOfWork dataset,IMapper mapper)
        {
            this.dataset = dataset;
            this.mapper = mapper;
        }

        public IEnumerable<RecipeDTO> GetRecipes()
        {
            var recipesList = dataset.Recipes.GetAll();
            var recipes = recipesList.Select(rec=> mapper.Map<RecipeDTO>(rec)).ToList();
            return recipes;
        }

        public IEnumerable<RecipeDTO> GetRecipesByCurrenctCategory(Guid categortId)
        {
            var recipesList = dataset.Recipes.GetAll().Where(x=>x.CategoryId.ToString()==categortId.ToString());
            var recipes = recipesList.Select(rec => mapper.Map<RecipeDTO>(rec)).ToList();
            return recipes;
        }
        public void Dispose()
        {
            dataset.Dispose();
        }
        public void AddNewRecipe(RecipeDTO recipeDTO)
        {
            try
            {
                     dataset.CreateTransaction();
                    var recipe = mapper.Map<Recipe>(recipeDTO);
                    foreach (var ingredient in recipe?.Ingredients)
                    {
                    //dataset.Products.Insert(ingredient.Products);
                    //foreach (var product in ingredient?.Products)
                    //{
                       dataset.Products.Delete(ingredient.Product);
                        dataset.Save();
                    //}
                    dataset.Ingredients.Insert(ingredient);
                    }
                    dataset.Save();
                    foreach (var recipeImage in recipe?.Images)
                    {
                        dataset.RecipeImages.Insert(recipeImage);
                    }
                    dataset.Save();
                    dataset.Recipes.Insert(recipe);
                    dataset.Save();
                    dataset.Commit();
                    Log.Information("Successfully added ner recipe to databse");

            }
            catch(Exception ex)
            {
                Log.Error(ex, "An error ocurred  when adding new recipe");
                Log.CloseAndFlush();
                dataset.Rollback();
            }
            
        }

       
    }
}


// var mapper = new MapperConfiguration(config => config.CreateMap<Data.Entitites.Recipe, Recipe>()).CreateMapper();
//return mapper.Map<IEnumerable< Data.Entitites.Recipe>,List<Recipe>>( dataset.Recipes.GetAll());
//AUTOMAPPER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//var recipe = dataset.Recipes.GetAll().FirstOrDefault();
//var recipeIngredients = new List<IngredientDTO>(recipe.Ingredients.Select
//    (x => mapper.Map<IngredientDTO>(x)));// new IngredientDTO(x.Id, x.Products.Select(pr => mapper.Map<ProductDTO>(x.Products)), x.Name, x.Weight, x.MeasurementUnit))); //new ProductDTO(pr.Id,pr.ProductName,mapper.Map<NutritionDTO>(pr.Nutrition) )),)));
////new NutritionDTO(pr.Nutrition.Id,pr.Nutrition.Calories,pr.Nutrition.Minerals, pr.Nutrition.Vitamins,pr.Nutrition.Fats,pr.Nutrition.Carbonhydrates,pr.Nutrition.Proteins)
//var recipeImages = new List<RecipeImageDTO>(recipe.Images.Select(x => mapper.Map<RecipeImageDTO>(x)));// new RecipeImageDTO(x.Id, x.ImagePath)));
//var recipeDTO = mapper.Map<RecipeDTO>(recipe);// new RecipeDTO( recipe.Id,recipe.Images.FirstOrDefault().ImagePath,recipe.RecipeName,recipe.ShortDescription, recipeIngredients, recipe.TotalWeight,
//    recipe.RecipeDetails?.VideoPath,recipe.RecipeDetails?.Notes,recipe.RecipeDetails?.Instruction,recipe.RecipeDetails?.IsFavourite
//    ,recipe.RecipeDetails?.Source,recipe.RecipeDetails?.Rating,recipe.RecipeDetails?.NumberOfServings,recipe.RecipeDetails.CookTime, recipeImages);
//

            //var nutrition = recip.Ingredients.
            ////var recDto = new RecipeDTO(recip.Id, recip.Images.FirstOrDefault().ImagePath, recip.RecipeName, recip.ShortDescription, recip.Ingredients.Select(ingred => new IngredientDTO(ingred.Id, new ProductDTO(ingred.Products.FirstOrDefault().Id, ingred.Products.FirstOrDefault().ProductName,
            //    new NutritionDTO(ingred.Products.FirstOrDefault().Nutrition.Id, ingred.Products.FirstOrDefault().Nutrition.Calories, ingred.Products.FirstOrDefault().Nutrition.Minerals, ingred.Products.FirstOrDefault().Nutrition.Vitamins, ingred.Products.FirstOrDefault().Nutrition.Fats
            //    , ingred.Products.FirstOrDefault().Nutrition.Carbonhydrates, ingred.Products.FirstOrDefault().Nutrition.Proteins))
            //    , ingred.Weight, ingred.MeasurementUnit)).ToList());
            //var recipes2 = dataset.Recipes.GetAll().ToList().Select(rec=>new RecipeDTO(rec.Id,rec.Images.FirstOrDefault().ImagePath,rec.RecipeName,rec.ShortDescription,null)).ToList();
            //var recipes = dataset.Recipes.GetAll().Select(recipe=>new RecipeDTO(recipe.Id, recipe.Images.FirstOrDefault().ImagePath,recipe.RecipeName,recipe.ShortDescription,recipe.Ingredients.
            //    Select(ingred=>new IngredientDTO(ingred.Id,new ProductDTO(ingred.Products.FirstOrDefault().Id, ingred.Products.FirstOrDefault().ProductName,
            //    new NutritionDTO(ingred.Products.FirstOrDefault().Nutrition.Id, ingred.Products.FirstOrDefault().Nutrition.Calories, ingred.Products.FirstOrDefault().Nutrition.Minerals, ingred.Products.FirstOrDefault().Nutrition.Vitamins, ingred.Products.FirstOrDefault().Nutrition.Fats
            //    , ingred.Products.FirstOrDefault().Nutrition.Carbonhydrates, ingred.Products.FirstOrDefault().Nutrition.Proteins))
            //    , ingred.Weight,ingred.MeasurementUnit)).ToList()));
            //return recipes;