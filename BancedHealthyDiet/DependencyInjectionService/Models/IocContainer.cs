using DependencyInjectionService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DependencyInjectionService.Models
{
    public class IocContainer : IContainer
    {
        //
        Dictionary<Type, RegistrationModel> typeAndIstances = new Dictionary<Type, RegistrationModel>();
        public void RegisterInstance<Type, Implementation>()
            where Type : class
            where Implementation : class
        {
            RegisterType<Type, Implementation>(RegistrtionType.Instance);
        }

        private void RegisterType<Type, Implementation>(RegistrtionType instance)
            where Type : class
            where Implementation : class
        {
            if(typeAndIstances.ContainsKey(typeof(Type)))
            {
                typeAndIstances.Remove(typeof(Type));
            }
            typeAndIstances.Add(typeof(Type),
                new RegistrationModel
                {
                    RegistrtionType = instance,
                    typeOfObject = typeof(Implementation)
                });
        }

        public void RegisterSingletone<Type, Implementation>()
            where Type : class
            where Implementation : class
        {
            RegisterType<Type, Implementation>(RegistrtionType.Singleton);
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            object obj =null;
            if(typeAndIstances.ContainsKey(type))
            {
                RegistrationModel registrationModel = typeAndIstances[type];
                if(registrationModel != null)
                {
                    Type typeToCreate = registrationModel.typeOfObject;
                    ConstructorInfo[] constructorInfos = typeToCreate.GetConstructors();
                    var dependencyConstructor= constructorInfos.FirstOrDefault(item => item.CustomAttributes.
                    FirstOrDefault(atr => atr.AttributeType == typeof(TinyDependencyAttribute)) != null);
                    if(dependencyConstructor==null)
                    {
                        obj =CreateInstance(registrationModel);
                    }
                    else
                    {
                        ParameterInfo[] parameters = dependencyConstructor.GetParameters();
                        if(parameters.Count()==0)
                        {
                            obj = CreateInstance(registrationModel);
                        }
                        else
                        {
                            List<object> arguments = new List<object>();
                            foreach(var param in parameters)
                            {
                                Type paramType = param.ParameterType;
                                arguments.Add(this.Resolve(paramType));
                            }
                            obj = CreateInstance(registrationModel,arguments.ToArray());
                        }
                    }
                }
            }
            return obj;
        }

        private object CreateInstance(RegistrationModel registrationModel, object[] arguments = null)
        {
            object returnedObj = null;
            Type typeToCreate = registrationModel.typeOfObject;
            if(registrationModel.RegistrtionType == RegistrtionType.Instance)
            {
                returnedObj = InstanceCreationService.GetInstance().GetNewObject(typeToCreate, arguments);
            }
            else if(registrationModel.RegistrtionType == RegistrtionType.Singleton)
            {
                returnedObj =SingletoneCretingService.GetInstance().GetSingleton(typeToCreate, arguments);
            }
            return returnedObj;
        }

        internal enum RegistrtionType
        {
            Instance,
            Singleton
        }
        internal class RegistrationModel
        {
            internal Type typeOfObject { get; set; }
            internal RegistrtionType RegistrtionType { get; set; }
        }
    }
}
