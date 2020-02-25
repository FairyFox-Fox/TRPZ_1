using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data
{
   public class DataSet
    {
        private List<ProductDTO> products;
        public List<ProductDTO> Products
        {
            get => products;
            set
            {
                if (value != null)
                    products= value;
            }
        }
        private List<RecipeDTO> recipes;
        public List<RecipeDTO> Recipes
        {
            get => recipes;
            set
            {
                if (value != null)
                    recipes = value;
            }
        }
        public DataSet()
        {
            products = new List<ProductDTO>();
            recipes = new List<RecipeDTO>();
            DataIntializator dataIntializator = new DataIntializator(new JsonSerializator());
            dataIntializator.SeedWithData(this);

        }

        

    }
}
