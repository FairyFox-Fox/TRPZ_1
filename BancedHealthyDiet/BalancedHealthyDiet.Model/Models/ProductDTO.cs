using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class ProductDTO:BaseModel
    {
  
        private IEnumerable<IngredientDTO> ingredients;
        public IEnumerable<IngredientDTO> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
            }
        }
        private string productName;
        public string ProductName
        {
            get => productName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Имя продукта не указано");
                productName = value;
            }
        }

        private NutritionDTO nutrition; 
        public NutritionDTO Nutrition
        {
            get => nutrition;
            set
            {
               nutrition = value;
            }
        }
        public ProductDTO()
        {
                
        }
        public ProductDTO(Guid id,string name, NutritionDTO nutrition)
        {
            Id = id;
            this.productName = name;
            this.nutrition = nutrition;
        }
    }
}
