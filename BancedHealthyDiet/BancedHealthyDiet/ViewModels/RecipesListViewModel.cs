using BancedHealthyDiet.Commands;
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
   public class RecipesListViewModel : BaseViewModel, IPageViewModel
    {
       
       

        private ObservableCollection<Recipe> recipesCollection;
        public ObservableCollection<Recipe> RcipesCollection
        {
            get => recipesCollection ?? (recipesCollection = new ObservableCollection<Recipe>());
        }
        public RecipesListViewModel()
        {
            var dataSet = DataSet.GetInsatnce();
            this.recipesCollection = new ObservableCollection<Recipe>(dataSet.Recipes);
            //foreach (var recipe in recipesCollection)
            //    CalculateTotalNutrition(recipe);
        }
        private Recipe selectedRecipe;
        private List<Recipe> selectedRecipes;
        public List<Recipe> SelectedRecipes
        {
            get => selectedRecipes ?? (selectedRecipes = new List<Recipe>());
            set
            {
                selectedRecipes = value;
                OnPropertyChanged(nameof(SelectedRecipes));
            }
        }

        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set
            {
                selectedRecipe = value;

                OnPropertyChanged(nameof(SelectedRecipe));

            }
        }

        ICommand addRecipeToList;
        public ICommand AddRecipeToList
        {
            get
            {
                if (addRecipeToList == null)
                    addRecipeToList = new RelayCommand(method => AddSelectedRecipe());
                return addRecipeToList;
            }
        }
        public void AddSelectedRecipe()
        {
            if (SelectedRecipe != null)
            {
                if (!SelectedRecipes.Contains(selectedRecipe))
                {
                    SelectedRecipes.Add(selectedRecipe);
                    ButtonTotalNutritionCollapsed = false;
                }
                Messenger.Default.Send<List<Recipe>>(SelectedRecipes);
            }
        }

        ICommand showRecipeDeatilViewCommand;
        private bool isDetailViewCollapsed = true;
        public bool IsDetailViewCollapsed
        {
            get => isDetailViewCollapsed;
            set
            {
                isDetailViewCollapsed = value;
                OnPropertyChanged(nameof(IsDetailViewCollapsed));
            }

        }
        public ICommand ShowRecipeDeatilViewCommand
        {
            get
            {
                if (showRecipeDeatilViewCommand == null)
                    showRecipeDeatilViewCommand = new RelayCommand(method => ShowRecipeDeatilView());

                return showRecipeDeatilViewCommand;

            }
        }

        private void ShowRecipeDeatilView()
        {

            IsDetailViewCollapsed = false;

        }


        private bool buttonTotalNutritionCollapsed = true;
        public bool ButtonTotalNutritionCollapsed
        {
            get
            {
                return buttonTotalNutritionCollapsed;
            }
            set
            {
                buttonTotalNutritionCollapsed = value;
                OnPropertyChanged(nameof(ButtonTotalNutritionCollapsed));
            }

        }
       
      


    }
}
