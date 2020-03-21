using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Model.Interfaces
{
    public interface IRecipeLogic
    {
        IEnumerable<RecipeDTO> GetRecipes();
        IEnumerable<RecipeDTO> GetRecipesByCurrenctCategory(Guid categortId);
        void AddNewRecipe(RecipeDTO recipeDTO);
        void Dispose();
    }
}
