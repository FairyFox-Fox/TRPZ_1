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
            CreateMap<Product, ProductDTO>();
            CreateMap<Ingredient, IngredientDTO>();

        }
    }
}
