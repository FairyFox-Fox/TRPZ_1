using BancedHealthyDiet.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.ViewModels
{
    public class AddRecipeViewModel :BaseViewModel, IPageViewModel
    {
        private readonly IRecipeLogic recipeLogic;

        public AddRecipeViewModel(IRecipeLogic recipeLogic)
        {
            this.recipeLogic = recipeLogic;
        }
    }
}
