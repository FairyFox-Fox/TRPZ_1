using System;
using System.Collections.Generic;

namespace BancedHealthyDiet.Models
{
    public class CategoryDTO
    {
        private Guid id;
        public Guid Id
        {
            get
            {
                if (id == Guid.Empty)
                    return id = Guid.NewGuid();
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("ImagePath is not valid");
                imagePath = value;
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name");
                else
                    name = value;
            }
        }
        private double countOfRecipes;
        public double CountOfRecipes
        {
            get => countOfRecipes;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("CountOfRecipes");
                countOfRecipes = value;
            }
        }
        private List<RecipeDTO> recipes;
        public List<RecipeDTO> Recipes
        {
            get => recipes ?? (recipes = new List<RecipeDTO>());
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Recipes");
                recipes = value;
            }
        }

    }
}