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
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Nutrition, NutritionDTO>();
            CreateMap<NutritionDTO, Nutrition>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<RecipeImage, RecipeImageDTO>();
            CreateMap<RecipeImageDTO, RecipeImage>();
            CreateMap<RecipeDTO, Recipe>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.RecipeName, s => s.MapFrom(x => x.RecipeName))
                .ForMember(x => x.Images.FirstOrDefault().ImagePath, s => s.MapFrom(x => x.ImagePath))
                .ForMember(x => x.Images, s => s.MapFrom(x => x.Images))
                .ForMember(x => x.ShortDescription, s => s.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.TotalWeight, s => s.MapFrom(x => x.TotalWeight))
                .ForMember(x => x.Ingredients, s => s.MapFrom(x => x.Ingredients))
                .ForMember(x => x.RecipeDetails.VideoPath, s => s.MapFrom(x => x.VideoPath))
                .ForMember(x => x.RecipeDetails.Notes, s => s.MapFrom(x => x.Notes))
                .ForMember(x => x.RecipeDetails.Instruction, s => s.MapFrom(x => x.Instruction))
                .ForMember(x => x.RecipeDetails.Source, s => s.MapFrom(x => x.Source))
                .ForMember(x => x.RecipeDetails.Rating, s => s.MapFrom(x => x.Rating))
                .ForMember(x => x.RecipeDetails.NumberOfServings, s => s.MapFrom(x => x.NumberOfServings))
                .ForMember(x => x.RecipeDetails.CookTime, s => s.MapFrom(x => x.CookTime));
            CreateMap<Recipe, RecipeDTO>()
                   .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                   .ForMember(x => x.RecipeName, s => s.MapFrom(x => x.RecipeName))
                   .ForMember(x => x.ImagePath , s => s.MapFrom(x => x.Images.FirstOrDefault().ImagePath))
                   .ForMember(x => x.Images, s => s.MapFrom(x => x.Images))
                   .ForMember(x => x.ShortDescription, s => s.MapFrom(x => x.ShortDescription))
                   .ForMember(x => x.TotalWeight, s => s.MapFrom(x => x.TotalWeight))
                   .ForMember(x => x.Ingredients, s => s.MapFrom(x => x.Ingredients))
                   .ForMember(x => x.VideoPath, s => s.MapFrom(x =>x.RecipeDetails.VideoPath))
                   .ForMember(x => x.Notes, s => s.MapFrom(x => x.RecipeDetails.Notes))
                   .ForMember(x => x.Instruction, s => s.MapFrom(x => x.RecipeDetails.Instruction ))
                   .ForMember(x => x.Source, s => s.MapFrom(x => x.RecipeDetails.Source))
                   .ForMember(x => x.Rating, s => s.MapFrom(x => x.RecipeDetails.Rating))
                   .ForMember(x => x.NumberOfServings, s => s.MapFrom(x => x.RecipeDetails.NumberOfServings ))
                   .ForMember(x => x.CookTime, s => s.MapFrom(x => x.RecipeDetails.CookTime));



        }
    }
}
