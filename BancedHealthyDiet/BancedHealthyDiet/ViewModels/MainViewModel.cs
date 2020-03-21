using BalancedHealthyDiet.Model.Integration;
using BalancedHealthyDiet.Model.Interfaces;
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
        private readonly IProductWithNutritionLIogic productLogic;
        private INutritionCalculator nutritionCalculator;


        public MainViewModel(IRecipeLogic data, INutritionCalculator nutritionCalculator, IRecipeCategoryLogic categoryLogic,
            CategoriesViewModel categoriesViewModel , IProductWithNutritionLIogic productLogic)//RecipesListViewModel recipesListViewModel
        {
            this.data = data;
            this.categoryLogic = categoryLogic;
            this.productLogic = productLogic;
            this.nutritionCalculator = nutritionCalculator;
            this.CurrentPageViewModel = categoriesViewModel;
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
        private ICommand goToRecipeCalculator;
        public ICommand GoToRecipeCalculator
        {
            get
            {
                Messenger.Default.Register<List<RecipeDTO>>(this, HandleRecipeCalulatorClick);
                if (goToRecipeCalculator == null)
                    goToRecipeCalculator = new RelayCommand(action => CurrentPageViewModel = new RecipesListViewModel(data));
                return goToRecipeCalculator;
            }
        }

        private void HandleRecipeCalulatorClick(List<RecipeDTO> obj)
        {
            
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
        private ICommand goToItem;

        public ICommand GoToItem
        {
            get
            {
                Messenger.Default.Register<RecipeDTO>(this, HandleSelectedItem);
                if (goToItem == null)
                    goToItem = new RelayCommand(action => CurrentPageViewModel = new ItemViewModel(categoryLogic,nutritionCalculator,SelectedItem));
                return goToItem;
            }
        }

        private ICommand goToAddRecipe;
        public ICommand GoToAddRecipe
        {
            get
            {
                if (goToAddRecipe == null)
                    goToAddRecipe = new RelayCommand(action => CurrentPageViewModel = new AddRecipeViewModel(data, categoryLogic, productLogic, nutritionCalculator));
                return goToAddRecipe;
            }
        }
        public Guid SelectedId { get; private set; }
        public RecipeDTO SelectedItem { get; private set; }

        public List<RecipeDTO> SelectedRecipes { get; private set; }
        private void HandleSelectedItem(RecipeDTO obj)
        {
            this.SelectedItem = obj;
        }
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
