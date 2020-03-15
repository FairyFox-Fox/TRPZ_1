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
            get => imagePath;
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

       // private string instruction;
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

        private List<IngredientDTO> ingredients;
        public List<IngredientDTO> Ingredients
        {
            get => ingredients ?? (ingredients= new List<IngredientDTO>());
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Ingredients");
                else if (value.Count() <= 0)
                    throw new ArgumentOutOfRangeException("Ingredients");
                ingredients = value;
            }
        }

        private double totalWeight;
        public double TotalWeight
        {
            get => totalWeight;
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
            get => totalNutrition;
            set
            {
                if(value==null)
                    throw new ArgumentNullException("TotalNutritionr");
                totalNutrition = value;
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
        private string videoPath;
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
        public string Notes { get; set; }

        public RecipeDTO(Guid id,string imagePath, string recipeName, string instruction, List<IngredientDTO> ingredients)
        {
            Id = id;
            ImagePath = imagePath;
            RecipeName = recipeName;
            Instruction = instruction;
            Ingredients = ingredients;
            TotalWeight = GetTotalWeight(Ingredients);
            ///what to do here&&&&&&&
            TotalNutrition = new NutririonCalculator().CalculateTotalNutrition(this);
            
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
