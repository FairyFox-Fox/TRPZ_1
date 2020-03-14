using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class RecipeDetails:IEntity
    {
       // [ForeignKey("Recipe")]
        //one yo one
        public Guid Id { get; set; }
       // public virtual Recipe Recipe { get; set; }
        public string VideoPath { get; set; }
        public string Notes { get; set; }
        public string Instruction { get; set; }
        public bool IsFavourite { get; set; }
        public string Source { get; set; }
        //public virtual Nutrition Nutrition { get; set; }
        public int Rating { get; set; }
        public int NumberOfServings { get; set; }
        public Int64 CookTime { get; set; }
        public RecipeDetails()
        {
            this.Id = Guid.NewGuid();
        }

        public RecipeDetails(string videoPath, string notes, string instruction, bool isFavourite,
            string source, int rating, int numberOfServings, long cookTime):this()
        {
            VideoPath = videoPath;
            Notes = notes;
            Instruction = instruction;
            IsFavourite = isFavourite;
            Source = source;
            Rating = rating;
            NumberOfServings = numberOfServings;
            CookTime = cookTime;
        }
    }
}