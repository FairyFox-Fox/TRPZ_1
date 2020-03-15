using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Data.Interfaces;
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
    public class CategoriesViewModel:BaseViewModel,IPageViewModel
    {
        private IRecipeCategoryLogic data;
      
        private void HadleSelectedCategory(List<RecipeDTO> obj)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<CategoryDTO> categories;
        public ObservableCollection<CategoryDTO> Categories
        {
            get => categories = new ObservableCollection<CategoryDTO>(data.GetCategories()) ?? (categories = new ObservableCollection<CategoryDTO>());
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
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



        public CategoriesViewModel(IRecipeCategoryLogic data)
        {
            this.data = data;

        }
    }
}

