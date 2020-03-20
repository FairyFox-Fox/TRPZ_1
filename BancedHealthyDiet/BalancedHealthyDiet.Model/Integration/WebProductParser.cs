using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using Serilog;
using HtmlAgilityPack;
using BancedHealthyDiet.Models;
using BalancedHealhtDiet.Data.Entitites;
using System.Globalization;
using AutoMapper;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Model.Interfaces;

namespace BalancedHealthyDiet.Model.Integration
{
    public class WebProductParser
    {
        const string URL = "http://www.calorizator.ru/product";
        private readonly List<string> listUrl;
        private readonly IUnitOfWork dataset;
        private readonly IMapper mapper;

        public WebProductParser(IUnitOfWork dataset, IMapper mapper)
        {
            this.listUrl = new List<string>();
            this.dataset = dataset;
            this.mapper = mapper;

        }
        public void ParseTablesOfProduct()
        {
            try
            {
                var htmlWeb = new HtmlWeb();
                var htmlDoc = htmlWeb.Load(URL);
                var divNode = htmlDoc.DocumentNode.SelectNodes("//div[@class='node-content']/ul[@class='product']/li/a");
                foreach (var node in divNode)
                {
                    var valueUrl = node.Attributes["href"].Value;
                    listUrl.Add(valueUrl);
                }
                var tableLists = new List<List<string>>();
                foreach (var url in listUrl)
                {
                    var htmlUrlDocument = htmlWeb.Load("http://www.calorizator.ru/" + url);
                    var tableOfProducts = htmlUrlDocument.DocumentNode
                        .SelectSingleNode("//table[@class='views-table sticky-enabled cols-6']")?.Descendants("tr")
                            .Skip(1)
                            .Where(tr => tr.Elements("td").Count() > 1)
                            .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList());
                    if(tableOfProducts!=null)
                        tableLists.AddRange(tableOfProducts);
                    ; 
                }
                tableLists.ForEach(line =>
                {
                    line.RemoveAll(x => String.IsNullOrEmpty(x));
                    var lineArray = line.ToArray();
                    if(lineArray.Length==5)
                    {
                        var product = TryGetProduct(lineArray[0], lineArray[2], lineArray[3], lineArray[1], lineArray[4]);
                        if(product!=null)
                        {
                            AddDataToDatabase( product, product.Nutrition);
                        }
                    }

                });

            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error when parsing list of products for current criteria");
                Log.CloseAndFlush();
            }
            
        }
        private void AddDataToDatabase(Product product, Nutrition nutrition)
        {
            using (var transaction = dataset.CreateTransaction())
            {
                try
                {
                    //dataset.Nutritions.Insert(nutrition);
                    //dataset.Save();
                    dataset.Products.Insert(product);
                    dataset.Save();
                    dataset.Commit();
                    Log.Information("Product with nutrition was successfully added to database");

                }
                catch (Exception ex)
                {
                    dataset.Rollback();
                    Log.Error("Error while adding product with nutrition to database");
                    Log.CloseAndFlush();

                }
            }
        }
        private Product TryGetProduct(string name, string fat, string carbonHydrates, string proteins, string calories)
        {
            try
            {
                var product = new Product();
                var nutrition = new Nutrition();
                product.ProductName = name;
                nutrition.Fats = Double.Parse(fat, CultureInfo.InvariantCulture);
                nutrition.Carbonhydrates = Double.Parse(carbonHydrates, CultureInfo.InvariantCulture);
                nutrition.Proteins = Double.Parse(proteins, CultureInfo.InvariantCulture);
                nutrition.Calories = Double.Parse(calories, CultureInfo.InvariantCulture);
                product.Nutrition = nutrition;
                return product;
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error parsing product frow web service");
                Log.CloseAndFlush();
                return null;
            }
           
        }

        
 
    }
}
