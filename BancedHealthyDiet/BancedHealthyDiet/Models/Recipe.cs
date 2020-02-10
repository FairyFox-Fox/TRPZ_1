using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class Recipe
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
        private string recipeName;
        public string RecipeName
        {
            get => recipeName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("RecipeName is not valid");
                recipeName = value;
            }
        }

        private string instruction;
        public string Instruction
        {
            get => instruction;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Instruction is not valid");
                instruction = value;
            }
        }

        private List<Ingredient> ingredients;
        public List<Ingredient> Ingredients
        {
            get => ingredients ?? (ingredients= new List<Ingredient>());
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Ingredients");
                else if (value.Count() <= 0)
                    throw new ArgumentOutOfRangeException("Ingredients");
                ingredients = value;
            }
        }

        private double totalWeight;
        public double TotalWeight
        {
            get => totalWeight;
            set
            {
                if (value > 0)
                    totalWeight = value;
                else
                    throw new ArgumentOutOfRangeException("TotalWeight");
            }
        }
        private Nutrition totalNutrition;
        public Nutrition TotalNutrition
        {
            get => totalNutrition;
            set
            {
                if(value==null)
                    throw new ArgumentNullException("TotalNutritionr");
                totalNutrition = value;
            }
        }

        public Recipe(string imagePath, string recipeName, string instruction, List<Ingredient> ingredients)
        {
            ImagePath = imagePath;
            RecipeName = recipeName;
            Instruction = instruction;
            Ingredients = ingredients;
        }

       
    }
}
