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

namespace BancedHealthyDiet.Models
{
    public  class RecipesLogic:IRecipeLogic
    {
        IUnitOfWork dataset;
        IMapper mapper;
        public RecipesLogic(IUnitOfWork dataset)//IMAPPER
        {
            //this
            this.dataset = dataset;
           //change&&&&&&&&&&&&&&
            this.mapper = new Mapper(AutoMapperConfiguration.ConfigureAutoMapper());
        }

        public IEnumerable<RecipeDTO> GetRecipes()
        {
            // var mapper = new MapperConfiguration(config => config.CreateMap<Data.Entitites.Recipe, Recipe>()).CreateMapper();
            //return mapper.Map<IEnumerable< Data.Entitites.Recipe>,List<Recipe>>( dataset.Recipes.GetAll());
            //AUTOMAPPER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var recipe = dataset.Recipes.GetAll().FirstOrDefault();
            var recipeIngredients = new List<IngredientDTO>(recipe.Ingredients.Select
                (x => mapper.Map<IngredientDTO>(x)));// new IngredientDTO(x.Id, x.Products.Select(pr => mapper.Map<ProductDTO>(x.Products)), x.Name, x.Weight, x.MeasurementUnit))); //new ProductDTO(pr.Id,pr.ProductName,mapper.Map<NutritionDTO>(pr.Nutrition) )),)));
            //new NutritionDTO(pr.Nutrition.Id,pr.Nutrition.Calories,pr.Nutrition.Minerals, pr.Nutrition.Vitamins,pr.Nutrition.Fats,pr.Nutrition.Carbonhydrates,pr.Nutrition.Proteins)
            var recipeImages = new List<RecipeImageDTO>(recipe.Images.Select(x => mapper.Map<RecipeImageDTO>(x)));// new RecipeImageDTO(x.Id, x.ImagePath)));
            var recipeDTO = mapper.Map<RecipeDTO>(recipe);// new RecipeDTO( recipe.Id,recipe.Images.FirstOrDefault().ImagePath,recipe.RecipeName,recipe.ShortDescription, recipeIngredients, recipe.TotalWeight,
            //    recipe.RecipeDetails?.VideoPath,recipe.RecipeDetails?.Notes,recipe.RecipeDetails?.Instruction,recipe.RecipeDetails?.IsFavourite
            //    ,recipe.RecipeDetails?.Source,recipe.RecipeDetails?.Rating,recipe.RecipeDetails?.NumberOfServings,recipe.RecipeDetails.CookTime, recipeImages);
            //
            var recipesList = dataset.Recipes.GetAll();
            var recipes = recipesList.Select(rec=> mapper.Map<RecipeDTO>(rec)).ToList();
            var r = new RecipeDTO();
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
            return recipes;
        }
        public void Dispose()
        {
            dataset.Dispose();
        }

       
    }
}
