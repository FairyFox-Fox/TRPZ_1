using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.ViewModels
{
    public class TotalNutritionViewModel: BaseViewModel, IPageViewModel
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
            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    totalNutrition = totalNutrition + ingredient.Product.Nutrition;
                }
            }
        }
    }
}
