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
    public class MainViewModel:BaseViewModel, IPageViewModel
    {

        public MainViewModel()
        {
            this.CurrentPageViewModel = new RecipesListViewModel();
        }
        private ICommand goToTotalNutrition;
        public ICommand GoToTotalNutrition
        {
            get
            {
                if (goToTotalNutrition == null)
                    goToTotalNutrition = new RelayCommand(action => CurrentPageViewModel = new TotalNutritionViewModel());
                return goToTotalNutrition;
            }
        }
    }
}
