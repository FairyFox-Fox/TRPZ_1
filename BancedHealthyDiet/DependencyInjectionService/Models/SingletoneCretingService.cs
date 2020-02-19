using System;
using System.Collections.Generic;

namespace DependencyInjectionService.Models
{
    internal class SingletoneCretingService
    {
        static SingletoneCretingService singletonInstance = null;
        static Dictionary<string, object> objectPool = new Dictionary<string, object>();
        static SingletoneCretingService()
        {
            singletonInstance = new SingletoneCretingService();
        }
        private SingletoneCretingService() { }
        public static SingletoneCretingService GetInstance()
        {
            return singletonInstance;
        }
        public object GetSingleton(Type type, object[] arguments = null)
        {
            object obj = null;
            try
            {
                if(objectPool.ContainsKey(type.Name)==false)
                {
                    obj = InstanceCreationService.GetInstance().GetNewObject(type, arguments);
                    objectPool.Add(type.Name, obj);
                }
                else
                {
                    obj = objectPool[type.Name];
                }
            }
            catch
            {
                //logs here
            }
            return obj;

        }
        //https://www.codeproject.com/Articles/1075189/Lets-write-a-Tiny-IoC-Container-to-learn-and-for-f
        //https://www.codeproject.com/Articles/347651/Define-Your-Own-IoC-Container
        //https://github.com/aspnet/DependencyInjection/blob/94b9cc9ace032f838e068702cc70ce57cc883bc7/src/DI.Abstractions/ServiceCollectionServiceExtensions.cs
    }
}