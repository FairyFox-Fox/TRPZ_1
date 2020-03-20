using AutoMapper;
using BalancedHealhtDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealthyDiet.Model.Integration
{
    public class RecipeCategoryLogic : IRecipeCategoryLogic
    {
        IUnitOfWork dataset;
        IMapper mapper;
        public RecipeCategoryLogic(IMapper mapper,IUnitOfWork dataset)
        {
            this.dataset = dataset;
            this.mapper = mapper;
        }
        public void Dispose()
        {
            dataset.Dispose();
        }

        public CategoryDTO GetCategory(Guid id)
        {
            var category =dataset.Categories.Get(id);
            return mapper.Map<CategoryDTO>(category);
        }
        public CategoryDTO GetCategoryByRecipeId(Guid recipeId)
        {
            var category = dataset.Recipes.Get(recipeId).Category; ;
            return mapper.Map<CategoryDTO>(category);
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categoriesList = dataset.Categories.GetAll();
            var categories = categoriesList.Select(cat => mapper.Map<CategoryDTO>(cat)).ToList();
            return categories;
        }

       
    }
}
