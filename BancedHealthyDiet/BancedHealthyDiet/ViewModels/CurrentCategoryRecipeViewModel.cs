using BancedHealthyDiet.Models;
using System.Collections.ObjectModel;

namespace BancedHealthyDiet.ViewModels
{
    internal class CurrentCategoryRecipeViewModel : BaseViewModel, IPageViewModel
    {
        private ObservableCollection<RecipeDTO> categoryRecipes;

        public CurrentCategoryRecipeViewModel(ObservableCollection<RecipeDTO> categoryRecipes)
        {
            this.categoryRecipes = categoryRecipes;
        }
    }
}