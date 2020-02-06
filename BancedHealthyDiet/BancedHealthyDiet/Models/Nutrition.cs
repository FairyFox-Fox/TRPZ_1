using System;

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
                if (proteins < 0)
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
                if (carbonhydrates < 0)
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
                if (fats < 0)
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
                if (vitamins < 0)
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
                if (minerals < 0)
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
                if (calories < 0)
                    throw new ArgumentOutOfRangeException("Calories");
                calories = value;
            }
        }

    }
}