﻿using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BalancedHealhtDiet.Data.Entitites
{
    public class Product:IEntity
    {
        
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public Guid? IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public virtual Nutrition Nutrition { get; set; }
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        public Product(string productName, Nutrition nutrition):this()
        {
            ProductName = productName;
            Nutrition = nutrition;
        }
    }
}
