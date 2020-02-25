using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Data.Interfaces
{
    public interface IDataComunicator
    {
        IList<RecipeDTO> GetAllRecipes();
    }
}
