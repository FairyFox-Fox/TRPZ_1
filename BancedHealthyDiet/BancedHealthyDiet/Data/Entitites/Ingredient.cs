using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancedHealthyDiet.Data.Entitites
{
    public class Ingredient
    {

        public Guid id { get; set; }
        public virtual Product Product { get; set; }
        public double Weight { get; set; }
        public string MeasurementUnit { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Ingredient()
        {
            this.id = Guid.NewGuid();
        }

    }
}
