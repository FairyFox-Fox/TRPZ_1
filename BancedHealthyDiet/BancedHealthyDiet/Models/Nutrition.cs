using System;
using System.Collections.Generic;

namespace BancedHealthyDiet.Models
{
    public class Nutrition
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

        private double proteins;
        public double Proteins
        {
            get => proteins;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Proteins");
                proteins = value;
            }
        }

        private double carbonhydrates;
        public double Carbonhydrates
        {
            get => carbonhydrates;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Carbonhydrates");
                carbonhydrates = value;
            }
        }

        private double fats;
        public double Fats
        {
            get => fats;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Fats");
                fats = value;
            }
        }

        private double vitamins;
        public double Vitamins
        {
            get => vitamins;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Vitamins");
                vitamins = value;
            }
        }

        private double minerals;
        public double Minerals
        {
            get => minerals;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Minerals");
                minerals = value;
            }
        }

        private double calories;
        public double Calories
        {
            get => calories;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Calories");
                calories = value;
            }
        }

        public static Nutrition operator +(Nutrition firstNutrition,Nutrition secondNutrition)
        {
            return new Nutrition
            {
                Calories = firstNutrition.Calories + secondNutrition.Calories,
                Minerals = firstNutrition.Minerals + secondNutrition.Minerals,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins,
                Fats = firstNutrition.Fats + secondNutrition.Fats,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins,
                Carbonhydrates = firstNutrition.Carbonhydrates + secondNutrition.Carbonhydrates
            };
        }

        public Nutrition(double calories=0, double minerals=0, double vitamins=0, double fats=0, double carbonhydrates=0, double proteins=0)
        {
            this.calories = calories;
            this.minerals = minerals;
            this.vitamins = vitamins;
            this.fats = fats;
            this.carbonhydrates = carbonhydrates;
            this.proteins = proteins;


        }
        public Nutrition CalculateTotalNutrition(Recipe recipe)
        {
            var totalNutrition = new Nutrition();
            foreach (var ingredient in recipe.Ingredients)
            {
                totalNutrition = CalculateNutrition(totalNutrition, ingredient.Product.Nutrition, ingredient.CheckWeight());
            }
            return totalNutrition;

        }

        private Nutrition CalculateNutrition(Nutrition firstNutrition, Nutrition secondNutrition, double weight)
        {

            return new Nutrition
            {
                Calories = firstNutrition.Calories + secondNutrition.Calories / 100 * weight,
                Minerals = firstNutrition.Minerals + secondNutrition.Minerals / 100 * weight,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins / 100 * weight,
                Fats = firstNutrition.Fats + secondNutrition.Fats / 100 * weight,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins / 100 * weight,
                Carbonhydrates = firstNutrition.Carbonhydrates + secondNutrition.Carbonhydrates / 100 * weight
            };
        }


        public Nutrition CalсulateTotalNutrition(List<Recipe> recipes)
        {
            var totalNutrition = new Nutrition();
            foreach (var recipe in recipes)
            {
                if (recipe.TotalNutrition != null)
                {
                    totalNutrition += recipe.TotalNutrition;

                }
                
            }
            return totalNutrition;
        }

    }
}