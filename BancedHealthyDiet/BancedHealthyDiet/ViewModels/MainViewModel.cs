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
        private IRecipeCategoryLogic categoryLogic;
        private INutritionCalculator nutritionCalculator;


        public MainViewModel(IRecipeLogic data, INutritionCalculator nutritionCalculator, IRecipeCategoryLogic categoryLogic,CategoriesViewModel categoriesViewModel )//RecipesListViewModel recipesListViewModel
        {
            this.data = data;
            this.categoryLogic = categoryLogic;
            this.nutritionCalculator = nutritionCalculator;
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
                    goToTotalNutrition = new RelayCommand(action => CurrentPageViewModel = new TotalNutritionViewModel(nutritionCalculator, SelectedRecipes));
                return goToTotalNutrition;
            }
        }
        private ICommand goToRecipesOfCurrentCategory;
        public ICommand GoToRecipesOfCurrentCategory
        {
            get
            {
                Messenger.Default.Register<Guid>(this, HandleSelectedCategory);
                if (goToRecipesOfCurrentCategory == null)
                    goToRecipesOfCurrentCategory = new RelayCommand(action => CurrentPageViewModel = new CurrentCategoryRecipeViewModel(data,categoryLogic, SelectedId));
                return goToRecipesOfCurrentCategory;
            }
        }
        //private ICommand goToItem;

        //public ICommand GoToItem
        //{
        //    get
        //    {
        //        return
        //     goToItem ?? (goToItem = new RelayCommand(x =>
        //     {

        //         Mediator.Notify("GoToItemView", SelectedRecipe);
        //     }));
        //    }
        //}
        public Guid SelectedId { get; private set; }

        public List<RecipeDTO> SelectedRecipes { get; private set; }

        private void HandleSelectedRecipe(List<RecipeDTO> obj)
        {
            this.SelectedRecipes = obj;
        }
        private void HandleSelectedCategory(Guid obj)
        {
            this.SelectedId = obj;
        }

    }
}
