using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class Ingredient
    {
        private Guid id;
        private Product product;
        public Product Product
        {
            get => product;
            set
            {
                if(value==null)
                    throw new ArgumentNullException("Product");
                else
                    product = value;
            }
        }
        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Weight");
                weight = value;
            }
        }

        private string measurementUnit;
      

        public Ingredient(Product product, double weight, string measurementUnit)
        {
            Product = product;
            this.id = this.Product.Id;
            Weight = weight;
            MeasurementUnit = measurementUnit;
        }

        public string MeasurementUnit
        {
            get => measurementUnit;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("MeasurementUnit name is not valid");
                measurementUnit = value;
            }
        }

        internal double CheckWeight()
        {
            switch (MeasurementUnit)
            {
                case "gr":
                    return Weight;
                case "kg":
                    return Weight * 1000;
                case "l":
                    return Weight * 1000;
                case "glasses (200 ml)":
                    return Weight * 200;
                case "ml":
                    return Weight;
                case "tsp":
                    return Weight * 5;
                case "tbsp":
                    return Weight * 15;
                case "on taste":
                    return Weight * 0;
                default:
                    return Weight;
            }
        }

    }
}
