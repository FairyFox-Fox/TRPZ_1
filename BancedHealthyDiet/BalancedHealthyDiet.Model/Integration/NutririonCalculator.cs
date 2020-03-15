using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealthyDiet.Model.Integration
{
    public class NutririonCalculator: INutritionCalculator
    {

        public NutritionDTO CalсulateTotalNutrition(List<RecipeDTO> recipes)
        {
            var totalNutrition = new NutritionDTO();
            foreach (var recipe in recipes)
            {
                if (recipe.TotalNutrition != null)
                {
                    totalNutrition += recipe.TotalNutrition;
                }
            }
            return totalNutrition;
        }

        private NutritionDTO CalculateNutrition(NutritionDTO firstNutrition, NutritionDTO secondNutrition, double weight)
        {
            return new NutritionDTO
            {
                Calories = firstNutrition.Calories + secondNutrition.Calories / 100 * weight,
                Minerals = firstNutrition.Minerals + secondNutrition.Minerals / 100 * weight,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins / 100 * weight,
                Fats = firstNutrition.Fats + secondNutrition.Fats / 100 * weight,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins / 100 * weight,
                Carbonhydrates = firstNutrition.Carbonhydrates + secondNutrition.Carbonhydrates / 100 * weight
            };
        }

        public NutritionDTO CalculateTotalNutrition(RecipeDTO recipe)
        {
            var totalNutrition = new NutritionDTO();
            foreach (var ingredient in recipe.Ingredients)
            {
                foreach(var product in ingredient?.Products)
                {
                    totalNutrition = CalculateNutrition(totalNutrition, product?.Nutrition, ingredient.CheckWeight());
                }
            }
            return totalNutrition;
        }
    }
}
