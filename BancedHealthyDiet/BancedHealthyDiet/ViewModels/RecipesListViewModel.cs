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
   public class RecipesListViewModel : BaseViewModel, IPageViewModel
    {
        private IRecipeLogic data;

        //private readonly IDataComunicator data;
        private ObservableCollection<RecipeDTO> recipesCollection;
        public ObservableCollection<RecipeDTO> RcipesCollection
        {
            get => recipesCollection=new ObservableCollection<RecipeDTO>(data.GetRecipes()) ?? (recipesCollection = new ObservableCollection<RecipeDTO>());
        }
        public RecipesListViewModel(IRecipeLogic data)
        {
            this.data = data;
            // this.recipesCollection = new ObservableCollection<Recipe>(data.GetRecipes());
        }
        public RecipesListViewModel()
        {
                
        }
        private RecipeDTO selectedRecipe;
        private List<RecipeDTO> selectedRecipes;
        public List<RecipeDTO> SelectedRecipes
        {
            get => selectedRecipes ?? (selectedRecipes = new List<RecipeDTO>());
            set
            {
                selectedRecipes = value;
                OnPropertyChanged(nameof(SelectedRecipes));
            }
        }

        public RecipeDTO SelectedRecipe
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
        private void AddSelectedRecipe()
        {
            if (SelectedRecipe != null)
            {
                if (!SelectedRecipes.Contains(selectedRecipe))
                {
                    SelectedRecipes.Add(selectedRecipe);
                    ButtonTotalNutritionCollapsed = false;
                }
                Messenger.Default.Send<List<RecipeDTO>>(SelectedRecipes);
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
