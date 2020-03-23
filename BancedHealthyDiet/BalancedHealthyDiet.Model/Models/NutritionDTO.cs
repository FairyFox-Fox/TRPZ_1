using System;
using System.Collections.Generic;

namespace BancedHealthyDiet.Models
{
    public class NutritionDTO:BaseModel
    {

        private double proteins;
        public double Proteins
        {
            get => proteins;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Белки");
                proteins = value;
                OnPropertyChanged(nameof(Proteins));
            }
        }

        private double carbonhydrates;
        public double Carbonhydrates
        {
            get => carbonhydrates;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество углеводов");
                carbonhydrates = value;
                OnPropertyChanged(nameof(Carbonhydrates));
            }
        }

        private double fats;
        public double Fats
        {
            get => fats;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество жиров");
                fats = value;
                OnPropertyChanged(nameof(Fats));
            }
        }

        private double vitamins;
        public double Vitamins
        {
            get => vitamins;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество витаминов");
                vitamins = value;
                OnPropertyChanged(nameof(Vitamins));
            }
        }

        private double minerals;
        public double Minerals
        {
            get => minerals;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество минералов");
                minerals = value;
                OnPropertyChanged(nameof(Minerals));
            }
        }

        private double calories;
        public double Calories
        {
            get => calories;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество калорий");
                calories = value;
                OnPropertyChanged(nameof(Calories));
            }
        }

        public static NutritionDTO operator +(NutritionDTO firstNutrition,NutritionDTO secondNutrition)
        {
            return new NutritionDTO
            {
                Calories = firstNutrition.Calories + secondNutrition.Calories,
                Minerals = firstNutrition.Minerals + secondNutrition.Minerals,
                Proteins = firstNutrition.Proteins + secondNutrition.Proteins,
                Fats = firstNutrition.Fats + secondNutrition.Fats,
                Vitamins = firstNutrition.Vitamins + secondNutrition.Vitamins,
                Carbonhydrates = firstNutrition.Carbonhydrates + secondNutrition.Carbonhydrates
            };
        }
        public NutritionDTO()
        {
            this.Id = Guid.NewGuid();
        }

        public NutritionDTO(Guid id,double calories=0, double minerals=0, double vitamins=0, double fats=0, double carbonhydrates=0, double proteins=0)
        {
            Id = id;
            this.calories = calories;
            this.minerals = minerals;
            this.vitamins = vitamins;
            this.fats = fats;
            this.carbonhydrates = carbonhydrates;
            this.proteins = proteins;


        }


      


      

    }
}