using AutoMapper;
using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealthyDiet.Model.Integration
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureAutoMapper()
        {
          
            MapperConfiguration configuration = new MapperConfiguration(confg =>
             {

                 confg.CreateMap<Category, CategoryDTO>();
                 confg.CreateMap<CategoryDTO, Category>(); 
                 confg.CreateMap<Nutrition, NutritionDTO>();
                 confg.CreateMap<NutritionDTO, Nutrition>();
                 confg.CreateMap<Product, ProductDTO>();
                 confg.CreateMap<ProductDTO, Product>();
                 confg.CreateMap<Ingredient, IngredientDTO>();
                 confg.CreateMap<IngredientDTO, Ingredient>();
                 confg.CreateMap<RecipeImage, RecipeImageDTO>();
                 confg.CreateMap<RecipeImageDTO, RecipeImage>();
                 confg.CreateMap<RecipeDTO, Recipe>()
                     .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                     .ForMember(x=>x.CategoryId, s=>s.MapFrom(x=>x.CategoryId))
                     //.ForMember(x=>x.Category, s=>s.MapFrom(e=>Mapper.Map<CategoryDTO,Category>(e)))
                     .ForMember(x => x.RecipeName, s => s.MapFrom(x => x.RecipeName))
                     .ForMember(x => x.ShortDescription, s => s.MapFrom(x => x.ShortDescription))
                     .ForMember(x => x.TotalWeight, s => s.MapFrom(x => x.TotalWeight))
                     .ForPath(x => x.RecipeDetails.VideoPath, s => s.MapFrom(x => x.VideoPath))
                     .ForPath(x => x.RecipeDetails.Notes, s => s.MapFrom(x => x.Notes))
                     .ForPath(x => x.RecipeDetails.Source, s => s.MapFrom(x => x.Source))
                     .ForPath(x => x.RecipeDetails.Rating, s => s.MapFrom(x => x.Rating))
                     .ForPath(x => x.RecipeDetails.NumberOfServings, s => s.MapFrom(x => x.NumberOfServings))
                     .ForPath(x => x.RecipeDetails.CookTime, s => s.MapFrom(x => x.CookTime));
                 confg.CreateMap<Recipe, RecipeDTO>()
                        .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                        .ForMember(x => x.CategoryId, s => s.MapFrom(x => x.CategoryId))
                        .ForMember(x => x.RecipeName, s => s.MapFrom(x => x.RecipeName))
                        .ForMember(x => x.ShortDescription, s => s.MapFrom(x => x.ShortDescription))
                        .ForMember(x => x.TotalWeight, s => s.MapFrom(x => x.TotalWeight))
                        .ForMember(x => x.VideoPath, s => s.MapFrom(x => x.RecipeDetails.VideoPath))
                        .ForMember(x => x.Notes, s => s.MapFrom(x => x.RecipeDetails.Notes))
                        .ForMember(x => x.Instruction, s => s.MapFrom(x => x.RecipeDetails.Instruction))
                        .ForMember(x => x.Source, s => s.MapFrom(x => x.RecipeDetails.Source))
                        .ForMember(x => x.Rating, s => s.MapFrom(x => x.RecipeDetails.Rating))
                        .ForMember(x => x.NumberOfServings, s => s.MapFrom(x => x.RecipeDetails.NumberOfServings))
                        .ForMember(x => x.CookTime, s => s.MapFrom(x => x.RecipeDetails.CookTime));

             });
            return configuration;
        }
    }
    
}
