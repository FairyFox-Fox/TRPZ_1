using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data
{
    public class DataComunicator:IDataComunicator
    {
        DataSet dataSet;
        public DataComunicator()
        {
            this.dataSet = new DataSet();
        }
        public IList<Recipe> GetAllRecipes()
        {
            return dataSet.Recipes;
        }
    }
}
