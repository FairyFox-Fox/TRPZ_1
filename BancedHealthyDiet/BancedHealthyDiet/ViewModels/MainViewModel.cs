using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Models;
using BancedHealthyDiet.Models.Interfaces;
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


        public MainViewModel(IRecipeLogic data, RecipesListViewModel recipesListViewModel)
        {
            this.data = data;
            this.CurrentPageViewModel = recipesListViewModel;//new RecipeListB(model)
        }
        private ICommand goToTotalNutrition;
        public ICommand GoToTotalNutrition
        {
            get
            {
                Messenger.Default.Register<List<Recipe>>(this, HandleListOfSelectedRecipes);
                if (goToTotalNutrition == null )
                    goToTotalNutrition = new RelayCommand(action => CurrentPageViewModel = new TotalNutritionViewModel(SelectedRecipes));
                return goToTotalNutrition;
            }
        }

        public List<Recipe> SelectedRecipes { get; private set; }

        private void HandleListOfSelectedRecipes(List<Recipe> obj)
        {
            this.SelectedRecipes = obj;
        }

    }
}
