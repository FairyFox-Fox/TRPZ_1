using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BancedHealthyDiet.Data.Entitites
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public virtual Nutrition Nutrition { get; set; }
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
