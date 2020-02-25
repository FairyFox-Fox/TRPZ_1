using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BancedHealthyDiet.Data.Entitites
{
    public class Nutrition:IEntity
    {
       
        [ForeignKey("Product")]
        public Guid Id { get; set; }      
        public double Proteins { get; set; }
        public double Carbonhydrates{ get; set; }
        public double Fats{ get; set; }
        public double Vitamins { get; set; }
        public double Minerals { get; set; }
        public double Calories{ get; set; }
        public Nutrition()
        {
            this.Id = Guid.NewGuid();
        }
        //one to one 
        public virtual Product Product { get; set; }

    }
}

