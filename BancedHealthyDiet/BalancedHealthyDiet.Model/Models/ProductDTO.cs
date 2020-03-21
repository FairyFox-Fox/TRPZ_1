using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class ProductDTO
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
        private string productName;
        public string ProductName
        {
            get => productName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Product name is not valid");
                productName = value;
            }
        }
        public  IngredientDTO Ingredient { get; set; }

        private NutritionDTO nutrition; 
        public NutritionDTO Nutrition
        {
            get => nutrition;
            set
            {
                //if (value != null)
                    nutrition = value;
                //throw new ArgumentNullException("Nutrition");
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
