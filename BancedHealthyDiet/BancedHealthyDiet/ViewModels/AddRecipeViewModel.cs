using BalancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Commands;
using BancedHealthyDiet.Model.Interfaces;
using BancedHealthyDiet.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BancedHealthyDiet.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel, IPageViewModel
    {
        private readonly IRecipeLogic recipeLogic;
        private readonly IRecipeCategoryLogic categoryLogic;
        private readonly IProductWithNutritionLIogic productLogic;
        private readonly INutritionCalculator nutritionCalculator;

        public AddRecipeViewModel(IRecipeLogic recipeLogic, IRecipeCategoryLogic categoryLogic, IProductWithNutritionLIogic productLogic, INutritionCalculator nutritionCalculator)
        {
            this.recipeLogic = recipeLogic;
            this.categoryLogic = categoryLogic;
            this.productLogic = productLogic;
            this.nutritionCalculator = nutritionCalculator;
            var categories = categoryLogic.GetCategories();
            this.AllCategories = new ObservableCollection<CategoryDTO>(categories);

        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get => addCommand ?? (addCommand = new RelayCommand(ction => AddNewRecipe()));
        }

        private void AddNewRecipe()
        {
            newRecipe.Images = RecipeAddedImages.ToList();
            recipeLogic.AddNewRecipe(NewRecipe);
            NewRecipe = new RecipeDTO();
            IngredientsList = new ObservableCollection<IngredientDTO>();
            NewIngredient = new IngredientDTO();
            RecipeAddedImages = new ObservableCollection<RecipeImageDTO>();
            AllProducts = new ObservableCollection<ProductDTO>();
        }

        private bool isAdded = false;
        public bool IsAdded
        {
            get => isAdded;
            set
            {
                isAdded = value;
                OnPropertyChanged(nameof(IsAdded));
            }

        }
        private ICommand addImageFromInternet;
        public ICommand AddImageFromInternet
        {
            get => addImageFromInternet ?? (addImageFromInternet = new RelayCommand(action => AddImageFromInternetExecute()));
        }

        private void AddImageFromInternetExecute()
        {
            IsUrlImageNotTextBoxShowed = false;

        }
        private bool isUrlImageNotTextBoxShowed = true;
        public bool IsUrlImageNotTextBoxShowed
        {
            get => isUrlImageNotTextBoxShowed;
            set
            {
                isUrlImageNotTextBoxShowed = value;
                OnPropertyChanged(nameof(IsUrlImageNotTextBoxShowed));
            }

        }
        private ICommand addImageFromComputer;
        public ICommand AddImageFromComputer
        {
            get => addImageFromComputer ?? (addImageFromComputer = new RelayCommand(action => AddImageFromComputerExecute()));
        }


        private void AddImageFromComputerExecute()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.FileName = "Image";
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                RecipeAddedImages.Add(new RecipeImageDTO { ImagePath = openFileDialog.FileName, ImageDescription = "Шаг " + RecipeAddedImages.Count.ToString() });
            }
        }
        private ICommand addVideoFromInternet;
        public ICommand AddVideoFromInternet
        {
            get => addVideoFromInternet ?? (addVideoFromInternet = new RelayCommand(action => AddVideoFromInternetExecute()));
        }

        private void AddVideoFromInternetExecute()
        {
            IsUrlVideoNotTextBoxShowed = false;
        }

        private ICommand addVideoFromComputer;
        public ICommand AddVideoFromComputer
        {
            get => addVideoFromComputer ?? (addVideoFromComputer = new RelayCommand(action => AddVideoFromComputerExecute()));
        }

        private void AddVideoFromComputerExecute()
        {
            Microsoft.Win32.OpenFileDialog openDlg = new Microsoft.Win32.OpenFileDialog();

            openDlg.InitialDirectory = @"c:\";
            openDlg.ShowDialog();
            NewRecipe.VideoPath = openDlg.FileName;
        }

        private bool isUrlVideoNotTextBoxShowed = true;
        public bool IsUrlVideoNotTextBoxShowed
        {
            get => isUrlVideoNotTextBoxShowed;
            set
            {
                isUrlVideoNotTextBoxShowed = value;
                OnPropertyChanged(nameof(IsUrlVideoNotTextBoxShowed));
            }

        }
        private string webVideoPath;
        public string WebVideoPath
        {
            get => webVideoPath;
            set
            {
                webVideoPath = value;
                if (!String.IsNullOrEmpty(webVideoPath))
                {
                    NewRecipe.VideoPath = webVideoPath;
                    WebVideoPath = string.Empty;
                    IsUrlVideoNotTextBoxShowed = true;
                    OnPropertyChanged(nameof(WebVideoPath));
                }

            }
        }
        private string webImagePath;
        public string WebImagePath
        {
            get => webImagePath;
            set
            {
                webImagePath = value;
                if (!String.IsNullOrEmpty(webImagePath))
                {
                    RecipeAddedImages.Add(new RecipeImageDTO { ImagePath = webImagePath, ImageDescription = "Шаг " + RecipeAddedImages.Count.ToString() });
                    WebImagePath = string.Empty;
                    OnPropertyChanged(nameof(webImagePath));
                }

            }
        }

        private ObservableCollection<RecipeImageDTO> recipeAddedImages;
        public ObservableCollection<RecipeImageDTO> RecipeAddedImages
       {
            get => recipeAddedImages??(recipeAddedImages=new ObservableCollection<RecipeImageDTO>());
            set
            {
                recipeAddedImages = value;
                OnPropertyChanged(nameof(RecipeAddedImages));
            }
        }


        private ICommand addIngredientCommand;
        public ICommand AddIngredientCommand
        {
            get => addIngredientCommand ?? (addIngredientCommand = new RelayCommand(action => AddNewIngredient()));
        }

        private void AddNewIngredient()
        {
            if (NewIngredient != null)
            {
                var product = productLogic.GetProductByName(NewIngredient.Name);
               // product.Ingredient = NewIngredient;
                NewIngredient.Product =   product;
                IngredientsList.CollectionChanged += IngredientsList_CollectionChanged;
                IngredientsList.Add(NewIngredient);
                
                
                  NewIngredient = null;
            }
        }

        private void IngredientsList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            newRecipe.Ingredients = IngredientsList.ToList();
            var newRecipeNutritious = nutritionCalculator.CalculateNutritionPer100Gram( NewRecipe);
            if (newRecipeNutritious != null)
            {
                NewRecipe.TotalNutrition = newRecipeNutritious;
            }
        }

        private RecipeDTO newRecipe;
        public RecipeDTO NewRecipe
        {
            get
            {
                if (newRecipe == null)
                    return newRecipe = new RecipeDTO();
                return newRecipe;
            }
            set
            {
                newRecipe = value;
                OnPropertyChanged(nameof(NewRecipe));
            }
        }
        private List<string> measurements;
        public List<string> Measurements
        {
            get
            {
                if (measurements == null)
                {
                    measurements = new List<String> { "г.", "кг.", "л.", "стак. (200 мл)", "мл", "чайн. л.", "стол. л.", "по вкусу" };
                    return measurements;
                }
                return measurements;
            }
            set
            {
                measurements = value;
                OnPropertyChanged(nameof(Measurements));
            }
        }


        private IngredientDTO newIngredient;
        public IngredientDTO NewIngredient
        {
            get
            {
                if (newIngredient == null)
                    return newIngredient = new IngredientDTO();
                return newIngredient;
            }
            set
            {
                newIngredient = value;
                OnPropertyChanged(nameof(NewIngredient));
            }
        }
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                AllProducts = new ObservableCollection<ProductDTO>(productLogic.GetProductsByQuery(searchText));
                searchText = NewIngredient.Name??String.Empty;
                OnPropertyChanged(nameof(searchText));
            }
        }
        public ObservableCollection<CategoryDTO> AllCategories { get; private set; }
        private ObservableCollection<ProductDTO> allProducts;
        public ObservableCollection<ProductDTO> AllProducts 
        {
            get
            {
                if (allProducts == null)
                {
                    var products = productLogic.GetProductsByQuery(searchText);
                    return allProducts = new ObservableCollection<ProductDTO>(products);
                }
                return allProducts;
            }
            set
            {
                allProducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }

        private ObservableCollection<IngredientDTO> ingredientsList;
        public ObservableCollection<IngredientDTO> IngredientsList
        {
            get
            {
                if (ingredientsList == null)
                    return ingredientsList = new ObservableCollection<IngredientDTO>();
                return ingredientsList;
            }
            set
            {
                ingredientsList = value;
                OnPropertyChanged(nameof(IngredientsList));
            }
        }
        private List<int> countOfServingsList;
        public List<int> CountOfServingsList
        {
            get
            {
                if (countOfServingsList == null)
                {
                    countOfServingsList = new List<int>();
                    for (int i = 0; i < 21; i++)
                        countOfServingsList.Add(i);
                    return countOfServingsList;
                }
                return countOfServingsList;
            }
            set
            {
                countOfServingsList = value;
                OnPropertyChanged(nameof(CountOfServingsList));
            }
        }
    }
}
