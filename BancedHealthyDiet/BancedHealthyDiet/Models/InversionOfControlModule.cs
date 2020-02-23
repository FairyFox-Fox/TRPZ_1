using BancedHealthyDiet.Data.Interfaces;
using BancedHealthyDiet.Data.Repositories;
using DependencyInjectionService;
using DependencyInjectionService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancedHealthyDiet.Models
{
    public static  class InversionOfControlModule
    {
        public static void Configure(IOC iOC)
        {
            iOC.Register<IUnitOfWork, UnitOfWork>();
          //  iOC.RegisterInstance<IGenericRepository<>, Repository<>>();
        }

    }
}
