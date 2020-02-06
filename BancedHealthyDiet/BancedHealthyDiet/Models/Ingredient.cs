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
                if(product==null)
                    throw new ArgumentNullException("Product");
                product = value;
            }
        }
        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (weight < 0)
                    throw new ArgumentOutOfRangeException("Weight");
                weight = value;
            }
        }

        private string measurementUnit;
        public string MeasurementUnit
        {
            get => measurementUnit;
            set
            {
                if (String.IsNullOrEmpty(measurementUnit))
                    throw new ArgumentException("MeasurementUnit name is not valid");
                measurementUnit = value;
            }
        }
        public Ingredient()
        {
            this.id = this.Product.Id;
        }
    }
}
