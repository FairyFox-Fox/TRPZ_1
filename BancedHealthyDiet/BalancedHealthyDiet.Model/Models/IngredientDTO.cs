using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class IngredientDTO
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

        public IngredientDTO()
        {
            Id = Guid.NewGuid();
        }
        public IngredientDTO(Guid id,  string name,double weight, string measurementUnit)
        {
            Id = id;
            this.name = name;
            //this.id = this.Product.Id;
            Weight = weight;
            MeasurementUnit = measurementUnit;
        }
        public virtual Guid? ProductId { get; set; }
        public virtual ProductDTO Product { get; set; }
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
                case "г."://"gr":
                    return Weight;
                case "кг."://"kg":
                    return Weight * 1000;
                case "л."://"l":
                    return Weight * 1000;
                case "стак. (200 мл)"://"glasses (200 ml)":
                    return Weight * 200;
                case "мл":// "ml":
                    return Weight;
                case "чайн. л.":// "tsp":
                    return Weight * 5;
                case "стол. л."://"tbsp":
                    return Weight * 15;
                case "по вкусу":// "on taste":
                    return Weight * 0;
                default:
                    return Weight;
            }
        }

    }
}
