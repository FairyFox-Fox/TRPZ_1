using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data
{
    internal  class DataSet
    {
        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                if (value != null)
                    products= value;
            }
        }
        private List<Recipe> recipes;
        public List<Recipe> Recipes
        {
            get => recipes;
            set
            {
                if (value != null)
                    recipes = value;
            }
        }
        private static DataSet dataSetInstance;
        private  DataSet()
        {
            products = new List<Product>();
            recipes = new List<Recipe>();
            DataIntializator dataIntializator = new DataIntializator(new JsonSerializator());
            dataIntializator.SeedWithData(this);

        }
        public static DataSet GetInsatnce()
        {
            if (dataSetInstance == null)
                dataSetInstance = new DataSet();
            return dataSetInstance;
        }
    }
}
