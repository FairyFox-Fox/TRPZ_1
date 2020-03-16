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
    public class CategoriesViewModel:BaseViewModel,IPageViewModel
    {
        private IRecipeCategoryLogic data;
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
                Messenger.Default.Send(selectedId);
            }
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



        public CategoriesViewModel(IRecipeCategoryLogic data)
        {
            this.data = data;

        }
    }
}

