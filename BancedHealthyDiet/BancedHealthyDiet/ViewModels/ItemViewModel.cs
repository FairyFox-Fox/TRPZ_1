using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Model.Interfaces;
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
    public class ItemViewModel:BaseViewModel,IPageViewModel
    {
        INutritionCalculator data;
        IRecipeCategoryLogic recipeCategoryLogic;
        private RecipeDTO selectedRecipe;
        public RecipeDTO SelectedRecipe
        {
            get
            {
                return selectedRecipe;
            }
            set
            {
                selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");

            }
        }
        
        private RecipeImageDTO selectedImageOfRecipe;
        public RecipeImageDTO SelectedImageOfRecipe
        {
            get
            {
                return selectedImageOfRecipe;
            }
            set
            {
                selectedImageOfRecipe = value;
                OnPropertyChanged("SelectedImageOfRecipe");

            }
        }
        public ObservableCollection<RecipeImageDTO> ImagesViewsCollection { get; }
        public ObservableCollection<string> CurrentRecipeInstructions { get; }
        private NutritionDTO nutritionPer100Gramm;
        public NutritionDTO NutritionPer100Gramm
        {
            get
            {
                return nutritionPer100Gramm;
            }
            set
            {
                nutritionPer100Gramm = value;
                OnPropertyChanged("NutritionPer100Gramm");

            }
        }
        private CategoryDTO currentCategory;
        public CategoryDTO CurrentCategory
        {
            get
            {
                return currentCategory;
            }
            set
            {
                currentCategory = value;
                OnPropertyChanged("Category");

            }
        }

        public struct ImageView
        {
            public string ImagePath { get; set; }
            public string ItemDescription { get; set; }
        }
        public ItemViewModel(IRecipeCategoryLogic recipeCategoryLogic,INutritionCalculator data,RecipeDTO recipe)
        {
            this.data = data;
            this.recipeCategoryLogic = recipeCategoryLogic;
            if(recipe!=null)
            {
                this.data = data;
                SelectedRecipe = recipe;
                NutritionPer100Gramm = data.CalculateNutritionPer100Gram(SelectedRecipe);
                this.CurrentCategory = recipeCategoryLogic.GetCategoryByRecipeId(SelectedRecipe.Id);
                var images = SelectedRecipe.Images;
                this.ImagesViewsCollection = new ObservableCollection<RecipeImageDTO>(images);
                var instructions = SelectedRecipe.Instruction.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                this.CurrentRecipeInstructions = new ObservableCollection<string>(instructions);
            }




        }
    }
}
