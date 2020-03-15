﻿using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using BancedHealthyDiet.Model.Interfaces;
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


        public MainViewModel(IRecipeLogic data, RecipesListViewModel recipesListViewModel)//
        {
            this.data = data;
            this.CurrentPageViewModel = new UserControlVM(); //recipesListViewModel;//new RecipeListB(model)
        }
        public MainViewModel()
        {

        }
        private ICommand goToTotalNutrition;
        public ICommand GoToTotalNutrition
        {
            get
            {
                Messenger.Default.Register<List<RecipeDTO>>(this, HandleListOfSelectedRecipes);
                if (goToTotalNutrition == null )
                    goToTotalNutrition = new RelayCommand(action => CurrentPageViewModel = new TotalNutritionViewModel(SelectedRecipes));
                return goToTotalNutrition;
            }
        }

        public List<RecipeDTO> SelectedRecipes { get; private set; }

        private void HandleListOfSelectedRecipes(List<RecipeDTO> obj)
        {
            this.SelectedRecipes = obj;
        }

    }
}
