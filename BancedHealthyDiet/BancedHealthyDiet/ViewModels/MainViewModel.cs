using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BancedHealthyDiet.ViewModels
{
    public class MainViewModel:BaseViewModel, IPageViewModel
    {
        private IRecipeLogic data;


        public MainViewModel(IRecipeLogic data,CategoriesViewModel categoriesViewModel )//RecipesListViewModel recipesListViewModel
        {
            this.data = data;
            this.CurrentPageViewModel = categoriesViewModel; //recipesListViewModel;//new RecipeListB(model)
        }
        public MainViewModel()
        {

        }
        private ICommand goToTotalNutrition;
        public ICommand GoToTotalNutrition
        {
            get
            {
                Messenger.Default.Register<List<RecipeDTO>>(this, HandleSelectedRecipe);
                if (goToTotalNutrition == null )
                    goToTotalNutrition = new RelayCommand(action => CurrentPageViewModel = new TotalNutritionViewModel(SelectedRecipes));
                return goToTotalNutrition;
            }
        }
        private ICommand goToRecipesOfCurrentCategory;
        public ICommand GoToRecipesOfCurrentCategory
        {
            get
            {
                Messenger.Default.Register<ObservableCollection<RecipeDTO>>(this, HandleSelectedCategory);
                if (goToRecipesOfCurrentCategory == null)
                    goToRecipesOfCurrentCategory = new RelayCommand(action => CurrentPageViewModel = new CurrentCategoryRecipeViewModel(CategoryRecipes));
                return goToRecipesOfCurrentCategory;
            }
        }
        public ObservableCollection<RecipeDTO>  CategoryRecipes { get; private set; }

        public List<RecipeDTO> SelectedRecipes { get; private set; }

        private void HandleSelectedRecipe(List<RecipeDTO> obj)
        {
            this.SelectedRecipes = obj;
        }
        private void HandleSelectedCategory(ObservableCollection<RecipeDTO> obj)
        {
            this.CategoryRecipes = obj;
        }

    }
}
