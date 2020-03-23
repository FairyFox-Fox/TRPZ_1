using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class IngredientDTO:BaseModel
    {

        private string name;
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Добавьте название для ингредиента.");
                else
                    name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double weight;
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Вес ингредиента должен быть больше нуля");
                weight = value;
                OnPropertyChanged(nameof(Weight));
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
                    throw new ArgumentException("Единица измерения ингредиента не указана");
                measurementUnit = value;
                OnPropertyChanged(nameof(MeasurementUnit));
            }
        }

        internal double CheckWeight()
        {
            switch (MeasurementUnit)
            {
                case "г.":
                    return Weight;
                case "кг.":
                    return Weight * 1000;
                case "л.":
                    return Weight * 1000;
                case "стак. (200 мл)":
                    return Weight * 200;
                case "мл":
                    return Weight;
                case "чайн. л.":
                    return Weight * 5;
                case "стол. л.":
                    return Weight * 15;
                case "по вкусу":
                    return Weight * 0;
                default:
                    return Weight;
            }
        }

    }
}
