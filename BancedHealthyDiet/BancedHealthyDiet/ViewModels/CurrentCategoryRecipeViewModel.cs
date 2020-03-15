using BalancedHealthyDiet.Model.Integration;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;

namespace BancedHealthyDiet.ViewModels
{
    public class CurrentCategoryRecipeViewModel : BaseViewModel, IPageViewModel
    {
        IRecipeLogic data;
        IRecipeCategoryLogic recipeCategoryData;

        public CurrentCategoryRecipeViewModel(IRecipeLogic data, IRecipeCategoryLogic recipeCategoryLogic)
        {
            this.data = data;
            this.recipeCategoryData = recipeCategoryLogic;
        }
        public CurrentCategoryRecipeViewModel(IRecipeLogic data, IRecipeCategoryLogic recipeCategoryLogic, Guid selectedid):this(data,recipeCategoryLogic)
        {
            this.data = data;
            this.recipeCategoryData = recipeCategoryLogic;
            this.SelectedId = selectedid;
            this.SelectedCategory = recipeCategoryLogic.GetCategory(selectedid);
        }
        public CurrentCategoryRecipeViewModel()
        {
        }
        private ObservableCollection<RecipeDTO> recipes;
        public ObservableCollection<RecipeDTO> Recipes
        {
            get => recipes = new ObservableCollection<RecipeDTO>(data.GetRecipesByCurrenctCategory(this.SelectedCategory.Id)) ??
                (recipes = new ObservableCollection<RecipeDTO>());
            set
            {
                recipes = value;
                OnPropertyChanged("Recipes");
            }
        }
        private RecipeDTO selectedRecipe;
        public RecipeDTO SelectedRecipe
        {
            get
            {
                return selectedRecipe;
            }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }


        private CategoryDTO selectedCategory;
        public CategoryDTO SelectedCategory
        {
            get
            {

                return selectedCategory;
            }
            set
            {

                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");

            }
        }
        private Guid selectedId;
        public Guid SelectedId
        {
            get
            {

                return selectedId;
            }
            set
            {

                selectedId = value;
                OnPropertyChanged("SelectedId");

            }
        }

    }
}