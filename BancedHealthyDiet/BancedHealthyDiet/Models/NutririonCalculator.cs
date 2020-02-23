using BancedHealthyDiet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class NutririonCalculator: INutritionCalculator
    {

        public Nutrition CalсulateTotalNutrition(List<Recipe> recipes)
        {
            var totalNutrition = new Nutrition();
            foreach (var recipe in recipes)
            {
                if (recipe.TotalNutrition != null)
                {
                    totalNutrition += recipe.TotalNutrition;

                }

            }
            return totalNutrition;
        }

        private Nutrition CalculateNutrition(Nutrition firstNutrition, Nutrition secondNutrition, double weight)
        {

            return new Nutrition
            {
                Calories = firstNutrition.Calories + secondNutrition.Calories / 100 * weight,
                Minerals = firstNutrition.Minerals + secondNutrition.Minerals / 100 * weight,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins / 100 * weight,
                Fats = firstNutrition.Fats + secondNutrition.Fats / 100 * weight,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins / 100 * weight,
                Carbonhydrates = firstNutrition.Carbonhydrates + secondNutrition.Carbonhydrates / 100 * weight
            };
        }

        public Nutrition CalculateTotalNutrition(Recipe recipe)
        {
            var totalNutrition = new Nutrition();
            foreach (var ingredient in recipe.Ingredients)
            {
                totalNutrition = CalculateNutrition(totalNutrition, ingredient.Product.Nutrition, ingredient.CheckWeight());
            }
            return totalNutrition;

        }
    }
}
