using System;

namespace DependencyInjectionService.Models
{
    internal class InstanceCreationService
    {
        static InstanceCreationService staticInstance = null;
        static InstanceCreationService()
        {
            staticInstance = new InstanceCreationService();
        }
        public InstanceCreationService() { }
        public static InstanceCreationService GetInstance()
        {
            return staticInstance;
        }
        public object GetNewObject(Type type, object[] arguments = null)
        {
            object obj = null;
            try
            {
                obj = Activator.CreateInstance(type, arguments);
            }
            catch
            {
                //log it again
            }
            return obj;
        }
    }
}