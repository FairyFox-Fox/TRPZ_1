using BancedHealthyDiet.Models;
using BancedHealthyDiet.Models.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.ViewModels
{
    public class TotalNutritionViewModel: BaseViewModel, IPageViewModel
    {
        /// <summary>
        /// !!!!!!!!!!!!!!!!!!!!
        /// </summary>
        INutritionCalculator nutritionCalculator = new NutririonCalculator();
        public TotalNutritionViewModel(INutritionCalculator nutritionCalculator)
        {
            //this
            this.nutritionCalculator = nutritionCalculator;
        }
        public TotalNutritionViewModel()
        {
                
        }
        private Nutrition totalNutrition;

        public Nutrition TotalNutrition
        {
            get => totalNutrition;
            set
            {
                totalNutrition = value;
                OnPropertyChanged(nameof(TotalNutrition));
                
            }

        }
        public ObservableCollection<Nutrition> Consumo { get; private set; }
        public TotalNutritionViewModel(List<Recipe> selectedRecipes)
        {
            TotalNutrition = nutritionCalculator.CalсulateTotalNutrition(selectedRecipes);
            Consumo = new ObservableCollection<Nutrition>();
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Total Calories",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(totalNutrition.Calories) },
                    DataLabels = true
                }
            };
            SeriesOfValuesNutritionCollection = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Base info",
                    Values = new ChartValues<double> { totalNutrition.Carbonhydrates, totalNutrition.Fats, totalNutrition.Proteins, totalNutrition.Vitamins,
                    totalNutrition.Minerals}
                }

            };
            Labels = new[] { "Carbonhydrates", "Fats", "Proteins", "Vitamins", "Minerals" };
            Formatter = value => value.ToString("N");
        }

        public SeriesCollection SeriesOfValuesNutritionCollection { get; private set; }
        public SeriesCollection SeriesCollection { get; private set; }
        public string[] Labels { get; private set; }
        public Func<double, string> Formatter { private get; set; }
        public INutritionCalculator NutritionCalculator { get => nutritionCalculator; set => nutritionCalculator = value; }
    }
}
