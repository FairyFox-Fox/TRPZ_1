using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Model.Interfaces
{
    public interface IRecipeCategoryLogic
    {
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetCategory(Guid id);
        CategoryDTO GetCategoryByRecipeId(Guid recipeId);
        void Dispose();
    }
}
