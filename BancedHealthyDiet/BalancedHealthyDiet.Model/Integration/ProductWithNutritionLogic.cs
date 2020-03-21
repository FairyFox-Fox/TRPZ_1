using AutoMapper;
using BalancedHealthyDiet.Model.Interfaces;
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
    public class ProductWithNutritionLogic : IProductWithNutritionLIogic
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork dataset;

        public ProductWithNutritionLogic(IMapper mapper, IUnitOfWork dataset)
        {
            this.mapper = mapper;
            this.dataset = dataset;
        }
        public ProductDTO GetProductById(Guid id)
        {
          var product =  dataset.Products.Get(id);
            var productDto = mapper.Map<ProductDTO>(product);
            return productDto;
        }
        public ProductDTO GetProductByName(string name)
        {
            var product = dataset.Products.GetAll().Where(x => x.ProductName == name).FirstOrDefault();
            var productDTO = mapper.Map<ProductDTO>(product);
            return productDTO;
        }
        public List<ProductDTO> GetProductsByQuery(string query)
        {
            var productsDtoList = new List<ProductDTO>();
            try
            {
                if (!String.IsNullOrEmpty(query) )
                {
                    var products = dataset.Products.GetAll().Where(x => x.ProductName.ToUpperInvariant().Contains(query));
                    productsDtoList = products.Select(product => mapper.Map<ProductDTO>(product)).ToList();
                }
                else
                {
                    var products = dataset.Products.GetAll().Take(10);
                    productsDtoList = products.Select(product => mapper.Map<ProductDTO>(product)).ToList();

                }
                return productsDtoList;
            }
            catch (Exception ex)
            {
                Log.Error("Exeption on gettind products list by query" + ex.Message);
                return productsDtoList;
            }

        }
        public void Dispose()
        {
            dataset.Dispose();
        }
    }
}

