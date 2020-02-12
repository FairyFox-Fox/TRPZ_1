using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public  static class Constants
    {
        public static readonly List<string> measurements = new List<String> { "gr", "kg", "l", "glasses (200 ml)", "ml", "tsp", "tbsp", "on taste" };
        public static string FILE_PATH_TO_PRODUCTS = ConfigurationManager.AppSettings["PathToProducts"];
        public static string FILE_PATH_TO_RECIPES = ConfigurationManager.AppSettings["PathToRecipess"];
    }
}
