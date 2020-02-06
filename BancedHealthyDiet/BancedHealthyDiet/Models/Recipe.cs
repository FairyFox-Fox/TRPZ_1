﻿using System;
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
        private string recipeName;
        public string RecipeName
        {
            get => recipeName;
            set
            {
                if (String.IsNullOrEmpty(recipeName))
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
                if (String.IsNullOrEmpty(instruction))
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
        private Nutrition totalNutrition;
        public Nutrition TotalNutrition
        {
            get => totalNutrition;
            set
            {
                if(value==null)
                    throw new ArgumentNullException("TotalNutrition");
                totalNutrition = value;
            }
        }
    }
}
