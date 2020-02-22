using BancedHealthyDiet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancedHealthyDiet.Data.Entitites
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}
