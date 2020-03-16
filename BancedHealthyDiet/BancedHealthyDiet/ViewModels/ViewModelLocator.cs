/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BancedHealthyDiet"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/



using BalancedHealthyDiet.Model.Integration;
using BancedHealthyDiet.Models;
using CommonServiceLocator;
using DependencyInjectionService;

namespace BancedHealthyDiet.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private readonly IOC container;
        public ViewModelLocator()
        {
            container = new IOC();
            var resolvingContainer = new IocLocator(container);
            container.Register<RecipesListViewModel>();
            container.Register<TotalNutritionViewModel>();
            container.Register<CurrentCategoryRecipeViewModel>();
            container.Register<CategoriesViewModel>();
            container.Register<ItemViewModel>();
            //var node = container.Resolve<RecipesListViewModel>();
            container.Register<MainViewModel>();
        }
        public MainViewModel MainViewModel
        {
            get { return container.Resolve<MainViewModel>(); }

        }
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        //    public ViewModelLocator()
        //    {
        //        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        //        ////if (ViewModelBase.IsInDesignModeStatic)
        //        ////{
        //        ////    // Create design time view services and models
        //        ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
        //        ////}
        //        ////else
        //        ////{
        //        ////    // Create run time view services and models
        //        ////    SimpleIoc.Default.Register<IDataService, DataService>();
        //        ////}

        //        SimpleIoc.Default.Register<MainViewModel>();
        //    }

        //    public MainViewModel Main
        //    {
        //        get
        //        {
        //            return ServiceLocator.Current.GetInstance<MainViewModel>();
        //        }
        //    }

        //    public static void Cleanup()
        //    {
        //        // TODO Clear the ViewModels
        //    }
        //}

    }
}