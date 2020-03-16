using BalancedHealthyDiet.Model.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public class RecipeDTO
    {
        private Guid id;
        public Guid Id
        {
            get
            {
                if (id == Guid.Empty)
                    return id = Guid.NewGuid();
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string imagePath;
        public string ImagePath
        {
            get => imagePath??(imagePath=Images.FirstOrDefault()?.ImagePath);
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("ImagePath is not valid");
                imagePath = value;
            }
        }
        private string recipeName;
        public string RecipeName
        {
            get => recipeName;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("RecipeName is not valid");
                recipeName = value;
            }
        }
        private string shortDescription;
        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("ShortDescription is not valid");
                shortDescription = value;
            }
        }
        private List<IngredientDTO> ingredients;
        public List<IngredientDTO> Ingredients
        {
            get => ingredients ?? (ingredients= new List<IngredientDTO>());
            set
            {
                //if (value == null)
                //    throw new ArgumentNullException("Ingredients");
                //else if (value.Count() <= 0)
                //    throw new ArgumentOutOfRangeException("Ingredients");
                ingredients = value;
            }
        }
        private double totalWeight;
        public double TotalWeight
        {
            get => (totalWeight = GetTotalWeight(ingredients));
            set
            {
                if (value > 0)
                    totalWeight = value;
                else
                    throw new ArgumentOutOfRangeException("TotalWeight");
            }
        }
        private NutritionDTO totalNutrition;
        public NutritionDTO TotalNutrition
        {
            get => totalNutrition??(totalNutrition = new NutririonCalculator().CalculateTotalNutrition(this));
            set
            {
                if(value==null)
                    throw new ArgumentNullException("TotalNutritionr");
                totalNutrition = value;
            }
        }
        private CategoryDTO currentCategory;
        public CategoryDTO CurrentCategory
        {
            get => currentCategory;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("CurrentCategory");
                currentCategory = value;
            }
        }
        private string videoPath;
        public string VideoPath
        {
            get => videoPath;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("VideoPath is not valid");
                videoPath = value;
            }
        }
        private string notes;
        public string Notes
        {
            get => notes;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Notes is not valid");
                notes = value;
            }
        }
        private string instruction;
        public string Instruction
        {
            get => instruction;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Instruction is not valid");
                instruction = value;
            }
        }
        public bool? IsFavourite { get; set; }
        private string source;
        public string Source
        {
            get => source;
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Source  is not valid");
                source = value;
            }
        }
        private int? rating;
        public int? Rating
        {
            get => rating;
            set
            {
                if (value > 0 && value<=5)
                    rating = value;
                else
                    throw new ArgumentOutOfRangeException("Rating");
            }
        }
        private int? numberOfServings;
        public int? NumberOfServings
        {
            get => numberOfServings;
            set
            {
                if (value > 0 )
                    numberOfServings = value;
                else
                    throw new ArgumentOutOfRangeException("NumberOfServings");
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
                    throw new ArgumentOutOfRangeException("CookTime");
            }
        }
        private List<RecipeImageDTO> images;
        public List<RecipeImageDTO> Images
        {
            get => images ?? (images = new List<RecipeImageDTO>());
            set
            { 
            //    if (value == null)
            //        throw new ArgumentNullException("Images");
                images = value;
            }
        }
        public TimeSpan CookTimeValid
        {
            get { return TimeSpan.FromTicks(CookTime); }
            set { CookTime = value.Ticks; }
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
            return 0.0;
          
        }
          
            

      


    }
}
