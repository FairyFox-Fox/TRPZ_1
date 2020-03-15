using AutoMapper;
using BalancedHealthyDiet.Model.Integration;
using BancedHealthyDiet.Data.Repositories;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.ViewModels
{
    public  class UserControlVM:BaseViewModel,IPageViewModel
    {
        private IRecipeLogic data;
        private ObservableCollection<RecipeDTO> recipesCollection;
        public ObservableCollection<RecipeDTO> RcipesCollection
        {
            get => recipesCollection = new ObservableCollection<RecipeDTO>(data.GetRecipes()) ?? (recipesCollection = new ObservableCollection<RecipeDTO>());
        }
        public UserControlVM()
        {
            this.data = new RecipesLogic(new UnitOfWork(new BalancedHealhtDiet.Data.Configuration.BalanceDietAppContext()));
            // this.recipesCollection = new ObservableCollection<Recipe>(data.GetRecipes());
        }
    }
}
