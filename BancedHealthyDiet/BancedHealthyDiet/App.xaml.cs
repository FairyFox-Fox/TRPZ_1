using BancedHealthyDiet.Models;
using BancedHealthyDiet.Models.Interfaces;
using BancedHealthyDiet.ViewModels;
using DependencyInjectionService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BancedHealthyDiet
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender,StartupEventArgs e)
        {
            //IOC container = new IOC();
            ////container.Register<IUnitOfWork, UnitOfWork>();
            ////container.Register<IRecipeLogic, RecipesLogic>();
            ////container.Register<INutritionCalculator, NutririonCalculator>();
            //container.Register<MainViewModel>();
            //var mainVm=container.Resolve<MainViewModel>();
            //MainWindow = new MainWindow();
            //MainWindow.DataContext =mainVm;
            //MainWindow.Show();

        }
    }
}
