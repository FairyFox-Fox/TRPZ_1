using System;

namespace BancedHealthyDiet.Models
{
    public class RecipeImageDTO:BaseModel
    {

        private string imagePath;
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        private string imageDescription;
        public string ImageDescription
        {
            get => imageDescription;
            set
            {
                imageDescription = value;
                OnPropertyChanged(nameof(ImageDescription));
            }
        }

        public RecipeImageDTO()
        {
            Id = Guid.NewGuid();
        }
        public RecipeImageDTO(Guid id, string imagePath)
        {
            this.Id = id;
            this.imagePath = imagePath;
        }
    }
}