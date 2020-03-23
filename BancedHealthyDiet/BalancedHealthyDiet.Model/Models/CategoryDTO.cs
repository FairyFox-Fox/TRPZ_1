using System;
using System.Collections.Generic;

namespace BancedHealthyDiet.Models
{
    public class CategoryDTO :BaseModel
    {
        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Введите имя категории");
                else
                    name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private double countOfRecipes;
        public double CountOfRecipes
        {
            get => countOfRecipes = Recipes.Count;
            set
            {
                if (countOfRecipes < 0)
                    throw new ArgumentOutOfRangeException("Количество рецептов");
                countOfRecipes = value;
                OnPropertyChanged(nameof(CountOfRecipes));
            }
        }
        private List<RecipeDTO> recipes;
        public List<RecipeDTO> Recipes
        {
            get => recipes ?? (recipes = new List<RecipeDTO>());
            set
            {
                recipes = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

    }
}