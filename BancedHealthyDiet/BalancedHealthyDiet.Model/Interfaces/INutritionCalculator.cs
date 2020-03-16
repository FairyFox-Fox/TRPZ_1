using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Model.Interfaces
{
    public interface INutritionCalculator
    {
        NutritionDTO CalсulateTotalNutrition(List<RecipeDTO> recipes);
        NutritionDTO CalculateTotalNutrition(RecipeDTO recipe);
        NutritionDTO CalculateNutritionPer100Gram(RecipeDTO recipe);

    }
}
