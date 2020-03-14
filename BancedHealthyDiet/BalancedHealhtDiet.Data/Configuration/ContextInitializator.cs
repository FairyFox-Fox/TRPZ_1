using BalancedHealhtDiet.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedHealhtDiet.Data.Configuration
{
    public class ContextInitializator: DropCreateDatabaseAlways<BalanceDietAppContext>
    {
        protected override void Seed(BalanceDietAppContext context)
        {
           // Category category1 = new Category( "Закуски,бутерброды", 0, @"\Images\zakuski.jpg");
           // Category category2 = new Category("Вторые блюда", 0, @"\Images\seconDishes.jpg");
           // Category category3 = new Category("Мясные блюда", 0, @"\Images\meat.jpg");
           // Category category4 = new Category("Рыбные блюда", 0, @"\Images\fish.jpg");
           // Category category5 = new Category("Салаты", 0, @"\Images\salat.jpg");
           // Category category6 = new Category("Несладкая выпечка", 0, @"\Images\bakingWithoutSugar.jpg");
           // Category category7 = new Category("Сладкая выпечкка", 0, @"\Images\sweatBakery.jpg");
           // Category category8 = new Category("Торты", 0, @"\Images\cakes.jpg");
           // Category category9 = new Category("Десерты", 0, @"\Images\desserts.jpg");
           // Category category10 = new Category("Напитки", 0, @"\Images\drinks.jpg");
           // Category category11 = new Category("Первые блюда", 0, @"\Images\firstDishes.jpg");
           // context.Categories.AddRange(new List<Category> { category1, category2, category3, category4, category5, category6, category7, category8, category9, category10, category11 });
           // context.SaveChanges();
           // RecipeDetails recipeDetails = new RecipeDetails("https://www.youtube.com/watch?v=33Q-aXg1-u8",
           //     @"Хоть этот салат и легкий на первый взгляд нужно учитывать несколько моментов. Солить такой салат нужно непосредственно перед подачей. Так как овощи после добавления соли начнут быстро выделять сок и салат потеряет презентабельность. Семечки после нарезания помидора лучше удалить, без них салат более аккуратно выглядит." +
           //     " Если вы не можете приобрести крабовые палочки, их можно заменить крабовым мясом. И если не любите салаты, которые нарезаны соломкой, смело режьте все средним кубиком.," +
           //     " Подготовим все необходимые ингредиенты для приготовления салата с болгарским перцем, крабовыми палочками и помидорами. " + "\n" +
           //     "Крабовые палочки нужно предварительно разморозить если надо. Делаем это в холодильнике, а не в комнате. И следите, чтобы упаковка не было нарушена, это убережет вас от неприятных последствий.",
           //     "Крабовые палочки нарезаем тонкой соломкой и укладываем в миску." + "\n" +
           //     "Болгарский перец моем и вытираем, так как лишняя вода ускоряет процесс порчи продуктов.Удаляем плодоножку и семена.Разрезаем на четыре части и нарезаем наискосок тонкой соломкой.Добавляем в миску с крабовыми палочками." + "\n" +
           //     "Чеснок очищаем и натираем на мелкой терке.Но лучше всего чеснок очень мелко порубить.При таком измельчение чеснок не выделяем масло, и остается острым и ароматным, а не горьким.И конечно регулируем количество остроты по своему вкусу" + "\n" +
           //     "Помидору вымоем, вытрем и нарежем соломкой.Поэтому выбираем плотные, мясистые плоды с минимальным количеством семян.Добавляем порезанную помидору в миску с овощами и крабовыми палочками." + "\n" +
           //     "Сыр натираем на крупной терке и добавляем в миску с салатом.Вообще сыр можно брать на ваш вкус и чем острее сыр, тем ярче будет вкус у салата." + "\n" +
           //     "Добавляем майонез, солим и перемешиваем.Если вы не любите майонез или просто нельзя, добавьте сметану или густой натуральный йогурт.Или можно заправить смесью растительного масла, соевого соуса и лимонного сока." + "\n" +
           //     "Наш салат с болгарским перцем, крабовыми палочками и помидорами готов.Раскладываем по салатникам, или подаем в общем.Приятного аппетита.", false, "1000 menu", 3, 4, 9000000000);
           // Recipe recipe1 = new Recipe(category5, null, "Очень вкусный салат с крабовыми палочками", "САЛАТ С БОЛГАРСКИМ ПЕРЦЕМ КРАБОВЫМИ ПАЛОЧКАМИ И ПОМИДОРАМИ", 1200, recipeDetails);
           // context.Recipes.Add(recipe1);
           // Ingredient ingr1 = new Ingredient("Крабовые палочки", 125, "гр",recipe1);//CHANGE MESUREMENT UNIT
           // Ingredient ingr2 = new Ingredient("Помидоры", 125, "гр", recipe1);
           // Ingredient ingr3 = new Ingredient("Болгарский перец", 125, "гр", recipe1);
           // Ingredient ingr4 = new Ingredient( "Твёрдый сыр", 125, "гр", recipe1);
           // Ingredient ingr5 = new Ingredient( "Чеснок", 125, "зубч.", recipe1);
           // Ingredient ingr6 = new Ingredient( "Майонез", 125, "стол.л.", recipe1);
           // Ingredient ing7 = new Ingredient( "Соль", 1, "по вкусу", recipe1);
           // context.Ingredients.AddRange(new List<Ingredient> { ingr1, ingr2, ingr3, ingr4, ingr5, ingr6, ing7 });
           // Nutrition nutrition = new Nutrition(5, 33, 6, 0, 0.001, 206);
           // Product product1 = new Product(ingr1.Name, ingr1, new Nutrition(6, 10, 1, 0, 0.01, 73));
           // Product product2 = new Product(ingr2.Name, ingr2, new Nutrition(1.1, 3.8, 0.2, 0, 0.01, 23));
           // Product product3 = new Product(ingr3.Name, ingr3, new Nutrition(1.3, 5.7, 0, 0, 0.01, 27));
           // Product product4 = new Product("Сыр росийский", ingr4, new Nutrition(24.1, 0.3, 29.5, 0, 0.01, 366));
           // Product product5 = new Product(ingr5.Name, ingr5, new Nutrition(6.5, 29.9, 0.5, 0, 0.01, 143));
           // Product product6 = new Product("Майонез провансаль", ingr6, new Nutrition(3.1, 2.6, 37, 0, 0.01, 624));
           // recipe1.Ingredients = new List<Ingredient> { ingr1, ingr2, ingr3, ingr4, ingr5, ingr6 };
           // context.Products.AddRange(new List<Product> { product1, product2, product3, product4, product5, product6 });
           //// category5.Recipes = new List<Recipe> { recipe1 };
           // RecipeImage recipeImage1 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_9_max.jpg", recipe1);
           // RecipeImage recipeImage2 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_1_min.jpg", recipe1);
           // RecipeImage recipeImage3 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_2_min.jpg", recipe1);
           // RecipeImage recipeImage4 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_3_min.jpg", recipe1);
           // RecipeImage recipeImage5 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_4_min.jpg", recipe1);
           // RecipeImage recipeImage6 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_5_min.jpg", recipe1);
           // RecipeImage recipeImage7 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_7_min.jpg", recipe1);
           // RecipeImage recipeImage8 = new RecipeImage("https://static.1000.menu/img/content-v2/fd/f6/42423/salat-s-bolgarskim-percem-krabovymi-palochkami-i-pomidorami_1579018704_8_min.jpg", recipe1);
           // context.RecipeImages.AddRange(new List<RecipeImage> { recipeImage1, recipeImage2, recipeImage3, recipeImage4, recipeImage5, recipeImage6, recipeImage7, recipeImage8 });
           // //recipe1.Images = new List<RecipeImage> { recipeImage1, recipeImage2, recipeImage3, recipeImage4, recipeImage5, recipeImage6, recipeImage7, recipeImage8 };
           // context.SaveChanges();
           // base.Seed(context);
        }
    }
}
