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
                imagePath = value;
            }
        }
        private string imageDescription;
        public string ImageDescription
        {
            get => imageDescription;
            set
            {
                imageDescription = value;
            }
        }

        public RecipeImageDTO()
        {
            id = Guid.NewGuid();
        }
        public RecipeImageDTO(Guid id, string imagePath)
        {
            this.id = id;
            this.imagePath = imagePath;
        }
    }
}