using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionService
{
   public interface IContainer
    {
        void Register<ObjectType>() where ObjectType : class;
        void Register<ObjectType, ObjectImplementation>() where ObjectImplementation : class, ObjectType;
        void RegisterInstance<TType>(TType instance) where TType : class;
        void RegisterInstance<TType, TConcrete>(TConcrete instance) where TConcrete : class, TType;
        void RegisterSingleton<ObjectType>() where ObjectType : class;
        void RegisterSingleton<ObjectType, ObjectImplementation>() where ObjectImplementation : class, ObjectType;
        ObjectToResolve Resolve<ObjectToResolve>();
        object Resolve(Type type);
    }
}
