using System;

namespace BancedHealthyDiet.Models
{
    public class RecipeImageDTO
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

        public RecipeImageDTO()
        {
           
        }
        public RecipeImageDTO(Guid id, string imagePath)
        {
            this.id = id;
            this.imagePath = imagePath;
        }
    }
}