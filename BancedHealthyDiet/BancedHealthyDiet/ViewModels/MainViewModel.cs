using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BancedHealthyDiet.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private Nutrition totalNutrition;
        public Nutrition TotalNutrition
        {
            get => totalNutrition;
            set
            {
                totalNutrition = value;
                OnPropertyChanged(nameof(TotalNutrition));
            }
        }
        private void CalculateTotalNutrition(List<Recipe> recipes)
        {
            var totalNutrition = new Nutrition();
            foreach(var recipe in recipes)
            {
                foreach( var ingredient in recipe.Ingredients)
                {
                    totalNutrition = totalNutrition + ingredient.Product.Nutrition;
                }
            }
        }

        private ObservableCollection<Recipe> recipesCollection;
        public ObservableCollection<Recipe> RcipesCollection
        {
            get => recipesCollection ?? (recipesCollection = new ObservableCollection<Recipe>());
        }
        public MainViewModel()
        {
            var dataSet = DataSet.GetInsatnce();
            this.recipesCollection = new ObservableCollection<Recipe>(dataSet.Recipes);
        }
        private Recipe selectedRecipe;
        private List<Recipe> selectedRecipes;
        public List<Recipe> SelectedRecipes
        {
            get=>selectedRecipes??(selectedRecipes = new List<Recipe>());
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
        public void AddSelectedRecipe(Recipe selectedRecipe)
        {
            if(SelectedRecipe!=null)
            {
                if(!selectedRecipes.Contains(selectedRecipe))
                    selectedRecipes.Add(selectedRecipe);
            }
        }

        ICommand showRecipeDeatilViewCommand;
        private bool isDetailViewCollapsed;
        public bool IsDetailViewCollapsed
        {
            get => isDetailViewCollapsed;
        }
        public ICommand ShowRecipeDeatilViewCommand
        {
            get
            {
                if (isDetailViewCollapsed == null)
                    showRecipeDeatilViewCommand = new RelayCommand(method=>ShowRecipeDeatilView());
                return showRecipeDeatilViewCommand;
            }
        }

        private void ShowRecipeDeatilView()
        {
            isDetailViewCollapsed = true;
        }
    }
}
