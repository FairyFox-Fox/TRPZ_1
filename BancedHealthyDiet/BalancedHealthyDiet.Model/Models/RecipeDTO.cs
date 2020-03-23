using BalancedHealthyDiet.Model.Integration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class RecipeDTO : BaseModel
    {
       
        private string imagePath;
        public string ImagePath
        {
            get => imagePath??(imagePath=Images.FirstOrDefault()?.ImagePath);
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        private string recipeName;
        public string RecipeName
        {
            get => recipeName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Введите название рецепта");
                recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }
        private string shortDescription;
        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }
        private List<IngredientDTO> ingredients;
        public List<IngredientDTO> Ingredients
        {
            get => ingredients ?? (ingredients= new List<IngredientDTO>());
            set
            {
                if (value.Count() <= 0)
                    throw new ArgumentOutOfRangeException("Рецепт должен содержать хотя бы один ингредиент");
                ingredients = value;
                OnPropertyChanged(nameof(ingredients));
            }
        }
        private double totalWeight;
        public double TotalWeight
        {
            get => (totalWeight = GetTotalWeight(ingredients));
            set
            {
                    totalWeight = value;
                OnPropertyChanged(nameof(TotalWeight));
            }
        }
        private NutritionDTO totalNutrition;
        public NutritionDTO TotalNutrition
        {
            get => totalNutrition;//??(totalNutrition = new NutririonCalculator().CalculateTotalNutrition(this))
            set
            {
                totalNutrition = value;
                OnPropertyChanged(nameof(TotalNutrition));
            }
        }
        public Guid CategoryId { get; set; }
        private string videoPath;
        public string VideoPath
        {
            get => videoPath;
            set
            {
                videoPath = value;
                OnPropertyChanged(nameof(VideoPath));
            }
        }
        private string notes;
        public string Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
        private string instruction;
        public string Instruction
        {
            get => instruction;
            set
            {
                instruction = value;
                OnPropertyChanged(nameof(Instruction));
            }
        }
        public bool? IsFavourite { get; set; }
        private string source;
        public string Source
        {
            get => source;
            set
            {
                source = value;
                OnPropertyChanged(nameof(Source));
            }
        }
        private int? rating;
        public int? Rating
        {
            get => rating;
            set
            {
              rating = value;
            }
        }
        private int? numberOfServings;
        public int? NumberOfServings
        {
            get => numberOfServings;
            set
            {
                if (value > 0)
                    numberOfServings = value;
                else
                    throw new ArgumentOutOfRangeException("Количество порций должно быть больше нуля");
                OnPropertyChanged(nameof(NumberOfServings));
            }
        }
        private Int64 cookTime;
        public Int64 CookTime
        {
            get => cookTime;
            set
            {
                if (value > 0)
                    cookTime = value;
                else
                    throw new ArgumentOutOfRangeException("Время проготовления не указано");
                OnPropertyChanged(nameof(CookTime));
            }
        }
        public TimeSpan CookTimeValid
        {
            get { return TimeSpan.FromTicks(CookTime); }
            set { CookTime = value.Ticks; }
        }
        private List<RecipeImageDTO> images;
        public List<RecipeImageDTO> Images
        {
            get => images ?? (images = new List<RecipeImageDTO>());
            set
            { 
                images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        public RecipeDTO(Guid id,string imagePath, string recipeName, string instruction)
        {
            Id = id;
            ImagePath = imagePath;
            RecipeName = recipeName;
            Instruction = instruction;
        }
        public RecipeDTO()
        {
            Id = Guid.NewGuid();
        }
       
        public RecipeDTO(Guid id, string imagePath, string recipeName, string shortDescription, List<IngredientDTO> ingredients, double totalWeight,  string videoPath, string notes, string instruction,
            bool? isFavourite, string source, int? rating, int? numberOfServings, 
            long cookTime, List<RecipeImageDTO> images) : this(id, imagePath, recipeName, shortDescription)
        {
            this.ingredients = ingredients;
            this.totalWeight = totalWeight;
            this.shortDescription = shortDescription;
            this.videoPath = videoPath;
            this.notes = notes;
            this.instruction = instruction;
            this.IsFavourite = isFavourite;
            this.source = source;
            this.rating = rating;
            this.numberOfServings = numberOfServings;
            this.cookTime = cookTime;
            this.images = images;
           
        }

        private double GetTotalWeight(List<IngredientDTO> ingredients)
        {
            if(ingredients!=null)
            {
                var totalWeight = 0.0;
                foreach (var ingred in ingredients)
                {
                    totalWeight += ingred.CheckWeight();
                }
                return totalWeight;
            }
            return 0.1;
          
        }
          
            

      


    }
}
