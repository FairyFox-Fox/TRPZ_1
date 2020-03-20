using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealthyDiet.Model.Interfaces
{
    public interface IProductWithNutritionLIogic
    {
        List<ProductDTO> GetProductsByQuery(string query);
        void Dispose();
    }
}
