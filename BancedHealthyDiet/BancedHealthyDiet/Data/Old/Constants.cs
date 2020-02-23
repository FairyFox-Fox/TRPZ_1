using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public  static class Constants
    {
        public static readonly List<string> measurements = new List<String> { "gr", "kg", "l", "glasses (200 ml)", "ml", "tsp", "tbsp", "on taste" };
        public const string FILE_PATH_TO_PRODUCTS = "D:\\DataSet\\Products";
        public const string FILE_PATH_TO_RECIPES = "D:\\DataSet\\Recipes";
    }
}
