using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BancedHealthyDiet.Data
{
    internal class DataIntializator
    {
        private readonly ISerializator serializator;

        public DataIntializator(ISerializator serializator)
        {
            this.serializator = serializator;
        }


        internal void SeedWithData(DataSet dataSet)
        {
            dataSet.Products = serializator.DeserializeListFromFile<ProductDTO>(Constants.FILE_PATH_TO_PRODUCTS);
            dataSet.Recipes = serializator.DeserializeListFromFile<RecipeDTO>(Constants.FILE_PATH_TO_RECIPES);
        }
        
    }
}
//internal void InitWithData(DataSet dataSet)
//{

//    var product1 = new Product("sunflower oil", new Nutrition(884, 0, 0.0000418, 100, 0, 0));
//    var product2 = new Product("pack trimmed green beans", new Nutrition(31, 0, 0, 0, 3.6));
//    var product3 = new Product("soy sauce", new Nutrition(53, 0.001, 0, 0.6, 4.9, 8));
//    var product4 = new Product("whole milk", new Nutrition(61, 0, 0, 3, 3.5, 4.7));
//    var product5 = new Product(" heavy cream", new Nutrition(345, 0, 0, 37, 2.05, 2.79));
//    var product6 = new Product("granulated white sugar", new Nutrition(375, 0, 0, 0, 99.98, 0));
//    var product7 = new Product("unflavored gelatin powder", new Nutrition(94, 0, 0, 0.03, 0, 23.97));

//    var products = new List<Product> { product1, product2, product3, product4, product5, product6, product7 };
//    var listOfIngreditns = new List<Ingredient> {new Ingredient(product1,2,"tbsp"),
//        new Ingredient(product2,200,"gr"),
//        new Ingredient(product3,1,"tbsp")};
//    var listOfIngreditns2 = new List<Ingredient> {new Ingredient(product4,500,"gr"),
//        new Ingredient(product5,500,"ml"),
//        new Ingredient(product6,3,"tbsp"),
//     new Ingredient(product7,2.5,"tsp")};
//    var recipe = new Recipe("https://kirbiecravings.com/wp-content/uploads/2019/08/milk-pudding-330x330.jpg",
//    "JAPANESE MILK PUDDING", "Add milk, cream, sugar, vanilla to a large pot. Sprinkle gelatin over top. Stir with a whisk until gelatin is almost dissolved." +
//    "Warm pudding mixture over low heat on the stove.You do not want it to simmer or come to a boil.While the mixture is heating up, continue to stir with whisk " +
//    "until gelatin and sugar are completely dissolved.This should only take 1 - 2 minutes once the mixture begins to heat up. Once dissolved, remove from heat." +
//    "Pour pudding into small bowls / jars or similar containers.You should have about 20 oz of pudding mixture. I divided mine into 4 oz servings." +
//    "Place pudding containers into fridge to set.This will take about 4 - 6 hours.Once set, they can be eaten as is.You can also decorate the tops with" +
//    " fruit or syrup before eating.I recommend taking them out of the fridge 15 - 20 minutes before eating, which will yield a softer pudding. It can be eaten" +
//    " straight out of the fridge but the texture will be more firm.",listOfIngreditns);
//    var recipe2 = new Recipe("https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2016/12/green-beans.jpg?itok=r0ZJ0D_h",
//        "Stir-fried garlic green beans", "Heat the oil in a wok, then stir-fry the green beans for 5 mins until they start to brown. Add the garlic and continue to " +
//        "cook until just tinged brown, then splash in the oyster sauce and serve.", listOfIngreditns2);
//    serializator.SerializeObjectToFile<Recipe>(new List<Recipe> { recipe, recipe2 }, Constants.FILE_PATH_TO_RECIPES);
//    serializator.SerializeObjectToFile<Product>( products, Constants.FILE_PATH_TO_PRODUCTS);
//}