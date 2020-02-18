using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionService.Models.Interfaces
{
    public interface IContainer
    {
        void RegisterInstance<Type, Implementation>()
            where Type: class
            where Implementation : class;

        void RegisterSingletone<Type, Implementation>()
            where Type : class
            where Implementation : class;
        T Resolve<T>();
    }
}
