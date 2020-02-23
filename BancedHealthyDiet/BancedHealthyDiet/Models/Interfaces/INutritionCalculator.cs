using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models.Interfaces
{
    public interface INutritionCalculator
    {
        Nutrition CalсulateTotalNutrition(List<Recipe> recipes);
        Nutrition CalculateTotalNutrition(Recipe recipe);
    }
}
