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
    //{
    //    private Nutrition totalNutrition;
    //    public Nutrition TotalNutrition
    //    {
    //        get => totalNutrition;
    //        set
    //        {
    //            totalNutrition = value;
    //            OnPropertyChanged(nameof(TotalNutrition));
    //        }
    //    }
        //private void CalculateTotalNutrition(List<Recipe> recipes)
        //{
        //    var totalNutrition = new Nutrition();
        //    foreach(var recipe in recipes)
        //    {
        //        foreach( var ingredient in recipe.Ingredients)
        //        {
        //            totalNutrition = totalNutrition + ingredient.Product.Nutrition;
        //        }
        //    }
        //}

        private void CalculateTotalNutrition(Recipe recipe)
        {
            var totalNutrition = new Nutrition();
            foreach (var ingredient in recipe.Ingredients)
            {
                CheckWeight(ingredient);
                totalNutrition = CalculateNutrition(totalNutrition,ingredient.Product.Nutrition, ingredient.Weight);
                
            }
            recipe.TotalNutrition = totalNutrition;

        }
        private Nutrition CalculateNutrition(Nutrition firstNutrition, Nutrition secondNutrition, double weight)
        {
            
            return new Nutrition
            {
                Calories = firstNutrition.Calories/100*weight + secondNutrition.Calories / 100 * weight,
                Minerals = firstNutrition.Minerals / 100 * weight + secondNutrition.Minerals / 100 * weight,
                Proteins = firstNutrition.Proteins / 100 * weight + secondNutrition.Proteins / 100 * weight,
                Fats = firstNutrition.Fats / 100 * weight + secondNutrition.Fats / 100 * weight,
                Vitamins = firstNutrition.Vitamins / 100 * weight + secondNutrition.Vitamins / 100 * weight,
                Carbonhydrates = firstNutrition.Carbonhydrates / 100 * weight + secondNutrition.Carbonhydrates / 100 * weight
            };
        }

        private void CheckWeight(Ingredient ingredient)
        {
            switch (ingredient.MeasurementUnit)
            {
                case "gr":
                    return;
                case "kg":
                    ingredient.Weight=ingredient.Weight*1000;
                    break; 
                case "l":
                    ingredient.Weight = ingredient.Weight * 1000;
                    break;
                case "glasses (200 ml)":
                    ingredient.Weight = ingredient.Weight * 200;
                    break;
                case "ml":
                    return;
                case "tsp":
                    ingredient.Weight = ingredient.Weight * 5;
                    break;
                case "tbsp":
                    ingredient.Weight = ingredient.Weight * 15;
                    break;
                case "on taste":
                    ingredient.Weight = ingredient.Weight * 0;
                    break;
                default:
                    return;
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
            foreach (var recipe in recipesCollection)
                CalculateTotalNutrition(recipe);
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

        ICommand addRecipeToList;
        public ICommand AddRecipeToList
        {
            get {
                if (addRecipeToList == null)
                    addRecipeToList = new RelayCommand(method => AddSelectedRecipe());
                return addRecipeToList;
            }
        }
        public void AddSelectedRecipe()
        {
            if(SelectedRecipe!=null)
            {
                if(!SelectedRecipes.Contains(selectedRecipe))
                    SelectedRecipes.Add(selectedRecipe);
            }
        }

        ICommand showRecipeDeatilViewCommand;
        private bool isDetailViewCollapsed=true;
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
                    showRecipeDeatilViewCommand = new RelayCommand(method=>ShowRecipeDeatilView());
             
                return showRecipeDeatilViewCommand;
               
            }
        }

        private void ShowRecipeDeatilView()
        {

            IsDetailViewCollapsed = false;
           
        }
    }
}
