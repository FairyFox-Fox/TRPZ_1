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
        private void CalculateTotalNutrition(Recipe recipe)
        {
            var totalNutrition = new Nutrition();
            recipe.TotalWeight = CalculateTotalWeight(recipe);
            foreach (var ingredient in recipe.Ingredients)
            {
               
                totalNutrition = CalculateNutrition(totalNutrition, ingredient.Product.Nutrition, CheckWeight(ingredient));

            }
            recipe.TotalNutrition = totalNutrition;

        }
        private Nutrition CalculateNutrition(Nutrition firstNutrition, Nutrition secondNutrition, double weight)
        {

            return new Nutrition
            {
                Calories = firstNutrition.Calories  + secondNutrition.Calories / 100 * weight,
                Minerals = firstNutrition.Minerals  + secondNutrition.Minerals / 100 * weight,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins / 100 * weight,
                Fats = firstNutrition.Fats  + secondNutrition.Fats / 100 * weight,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins / 100 * weight,
                Carbonhydrates = firstNutrition.Carbonhydrates  + secondNutrition.Carbonhydrates / 100 * weight
            };
        }

        private double CheckWeight(Ingredient ingredient)
        {
            switch (ingredient.MeasurementUnit)
            {
                case "gr":
                    return ingredient.Weight;
                case "kg":
                    return ingredient.Weight * 1000;
                case "l":
                   return ingredient.Weight * 1000;
                case "glasses (200 ml)":
                   return ingredient.Weight * 200;
                case "ml":
                    return ingredient.Weight; 
                case "tsp":
                    return ingredient.Weight * 5;
                case "tbsp":
                   return ingredient.Weight * 15;
                case "on taste":
                    return ingredient.Weight * 0;
                default:
                    return ingredient.Weight;
            }
        }

        private ObservableCollection<Recipe> recipesCollection;
        public ObservableCollection<Recipe> RcipesCollection
        {
            get => recipesCollection ?? (recipesCollection = new ObservableCollection<Recipe>());
        }
        public RecipesListViewModel()
        {
            var dataSet = DataSet.GetInsatnce();
            this.recipesCollection = new ObservableCollection<Recipe>(dataSet.Recipes);
            foreach (var recipe in recipesCollection)
                CalculateTotalNutrition(recipe);
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

        public double CalculateTotalWeight(Recipe recipe)
        {
            var totalWeight = 0.0;
            foreach (var ingred in recipe.Ingredients)
            {
                totalWeight+= CheckWeight(ingred);
            }
            return totalWeight;

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
