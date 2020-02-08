using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class Product
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

        private Nutrition nutrition; 
        public Nutrition Nutrition
        {
            get => nutrition;
            set
            {
                if (value != null)
                    nutrition = value;
                throw new ArgumentNullException("Nutrition");
            }
        }
        public Product(string name, Nutrition nutrition)
        {
            this.productName = name;
            this.nutrition = nutrition;
        }
    }
}
