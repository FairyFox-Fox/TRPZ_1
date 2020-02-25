
using BancedHealthyDiet.Data.Entitites;
using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Data.Repositories;
using BancedHealthyDiet.Models;
using BancedHealthyDiet.Models.Interfaces;
using BancedHealthyDiet.ViewModels;
using DependencyInjectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace BancedHealthyDiet

{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var viewModel = new ViewModelLocator().MainViewModel;
            //DataContext = viewModel;

          
        }
    }
}




//  var vindow = new ViewModelLocator().MainViewModel;// new MainViewModel(new RecipesLogic(new UnitOfWork(new BalanceDietAppContext())), node);// new RecipesListViewModel(new RecipesLogic(new UnitOfWork(new BalanceDietAppContext()))
//this.DataContext = vindow;
//using (var context = new BalanceDietAppContext()) //container.Resolve<RecipesListViewModel>()
//{
//    var nut1 = new Nutrition { Calories = 884, Minerals = 0, Vitamins = 0.0000418, Fats = 100, Carbonhydrates = 0, Proteins = 0 };
//    var nut2 = new Nutrition { Calories = 31, Minerals = 0, Vitamins = 0, Fats = 0, Carbonhydrates = 3.6, Proteins = 2 };
//    var nut3 = new Nutrition { Calories = 53, Minerals = 0.001, Vitamins = 0, Fats = 0.6, Carbonhydrates = 4.9, Proteins = 8 };
//    var nut4 = new Nutrition { Calories = 61, Minerals = 0, Vitamins = 0, Fats = 3, Carbonhydrates = 3.5, Proteins = 4.7 };
//    var nut6 = new Nutrition { Calories = 345, Minerals = 0, Vitamins = 0, Fats = 37, Carbonhydrates = 2.05, Proteins = 2.79 };
//    var nut7 = new Nutrition { Calories = 375, Minerals = 0, Vitamins = 0, Fats = 0, Carbonhydrates = 99.98, Proteins = 0 };
//    var nut8 = new Nutrition { Calories = 94, Minerals = 0, Vitamins = 0, Fats = 0.03, Carbonhydrates = 0, Proteins = 23.97 };
//    var lisstNutr = new List<Nutrition> { nut1, nut2, nut3, nut4, nut6, nut7, nut8 };

//    var product1 = new Product { ProductName = "sunflower oil", Nutrition = nut1 };
//    var product2 = new Product { ProductName = "pack trimmed green beans", Nutrition = nut2 };
//    var product3 = new Product { ProductName = "soy sauce", Nutrition = nut3 };
//    var product4 = new Product { ProductName = "whole milk", Nutrition = nut4 };
//    var product5 = new Product { ProductName = " heavy cream", Nutrition = nut6 };
//    var product6 = new Product { ProductName = "granulated white sugar", Nutrition = nut7 };
//    var product7 = new Product { ProductName = "unflavored gelatin powder", Nutrition = nut8 };

//    var products = new List<Product> { product1, product2, product3, product4, product5, product6, product7 };
//    context.Products.AddRange(products.AsEnumerable());
//    context.SaveChanges();
//    context.Nutritions.AddRange(lisstNutr.AsEnumerable());
//    context.SaveChanges();
//    var listOfIngreditns = new List<Ingredient> {new Ingredient{Product= product1,Weight= 2,MeasurementUnit="tbsp" },
//        new Ingredient{Product=  product2,Weight= 200,MeasurementUnit="gr" },
//        new Ingredient { Product = product3, Weight = 1, MeasurementUnit = "tbsp" }};
//    var listOfIngreditns2 = new List<Ingredient> { new Ingredient{ Product=product4, Weight = 500, MeasurementUnit = "gr"},
//        new Ingredient{Product= product5,Weight=500,MeasurementUnit="ml" },
//        new Ingredient
//        {
//            Product = product6,
//            Weight = 3,
//            MeasurementUnit = "tbsp"
//        },
//     new Ingredient { Product = product7, Weight = 2.5, MeasurementUnit = "tsp" }
//        };
//    context.Ingredients.AddRange(listOfIngreditns);
//    context.Ingredients.AddRange(listOfIngreditns2);
//    context.SaveChanges();
//    var recipe = new Recipe
//    {
//        ImagePath = "https://kirbiecravings.com/wp-content/uploads/2019/08/milk-pudding-330x330.jpg",
//        RecipeName =
//    "JAPANESE MILK PUDDING",
//        Instruction = "Add milk, cream, sugar, vanilla to a large pot. Sprinkle gelatin over top. Stir with a whisk until gelatin is almost dissolved." +
//    "Warm pudding mixture over low heat on the stove.You do not want it to simmer or come to a boil.While the mixture is heating up, continue to stir with whisk " +
//    "until gelatin and sugar are completely dissolved.This should only take 1 - 2 minutes once the mixture begins to heat up. Once dissolved, remove from heat." +
//    "Pour pudding into small bowls / jars or similar containers.You should have about 20 oz of pudding mixture. I divided mine into 4 oz servings." +
//    "Place pudding containers into fridge to set.This will take about 4 - 6 hours.Once set, they can be eaten as is.You can also decorate the tops with" +
//    " fruit or syrup before eating.I recommend taking them out of the fridge 15 - 20 minutes before eating, which will yield a softer pudding. It can be eaten" +
//    " straight out of the fridge but the texture will be more firm.",
//        Ingredients = listOfIngreditns
//    };
//    var recipe2 = new Recipe
//    {
//        ImagePath = "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2016/12/green-beans.jpg?itok=r0ZJ0D_h",
//        RecipeName = "Stir-fried garlic green beans",
//        Instruction = "Heat the oil in a wok, then stir-fry the green beans for 5 mins until they start to brown. Add the garlic and continue to " +
//        "cook until just tinged brown, then splash in the oyster sauce and serve.",
//        Ingredients = listOfIngreditns2
//    };
//    context.Recipes.Add(recipe);
//    context.Recipes.Add(recipe2);
//    context.SaveChanges();
//}


