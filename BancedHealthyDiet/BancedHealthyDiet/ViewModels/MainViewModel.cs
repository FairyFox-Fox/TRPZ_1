using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Models;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Extensions.Configuration;
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

        public MainViewModel()
        {
            this.CurrentPageViewModel = new RecipesListViewModel();
        }
        private ICommand goToRecipeView;
        public ICommand GoToRecipeView
        {
            get
            {
                if (goToRecipeView == null)
                    goToRecipeView = new RelayCommand(action => CurrentPageViewModel = new RecipesListViewModel());
                return goToRecipeView;
            }
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
            IConfiguration
            this.SelectedRecipes = obj;
        }

    }
}
