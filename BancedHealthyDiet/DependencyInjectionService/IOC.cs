using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjectionService
{
    public class IOC
    {
        private readonly IDictionary<Type, DependencyObject> dependencyObjects;
        public IOC()
        {
            dependencyObjects = new Dictionary<Type, DependencyObject>();
        }
        public void Register<ObjectType>() where ObjectType : class
        {
            Register<ObjectType, ObjectType>(false, null);
        }
        public void Register<ObjectType, ObjectImplementation>() where ObjectImplementation : class, ObjectType
        {
            Register<ObjectType, ObjectImplementation>(false, null);
        }
        public void RegisterSingleton<ObjectType>() where ObjectType : class
        {
            RegisterSingleton<ObjectType, ObjectType>();
        }
        public void RegisterSingleton<ObjectType, ObjectImplementation>() where ObjectImplementation : class, ObjectType
        {
            Register<ObjectType, ObjectImplementation>(true, null);
        }

        public ObjectToResolve Resolve<ObjectToResolve>()
        {
            return (ObjectToResolve)ResolveObject(typeof(ObjectToResolve));
        }
        public object Resolve(Type type)
        {
            return ResolveObject(type);
        }
        private void Register<ObjectType, ObjectImplementation>(bool isSingleton, ObjectImplementation instance)
        {
            Type type = typeof(ObjectType);
            if (dependencyObjects.ContainsKey(type))
                dependencyObjects.Remove(type);
            dependencyObjects.Add(type, new DependencyObject(typeof(ObjectImplementation), isSingleton, instance));
        }
        private object ResolveObject(Type type)
        {

            if (dependencyObjects.ContainsKey(type) == false)
            {
                throw new ArgumentOutOfRangeException(string.Format("This object {0} has not been registered", type.Name));
            }
            var dependencyObject = dependencyObjects[type];
            return GetInstance(dependencyObject);
        }
        private object GetInstance(DependencyObject dependencyObject)
        {
            object instance = dependencyObject.SingletonInstance;
            if (instance == null)
            {
                var parameters = ResolveConstructorParameters(dependencyObject);
                instance = dependencyObject.CreateInstance(parameters.ToArray());
            }
            return instance;
        }
        private IEnumerable<object> ResolveConstructorParameters(DependencyObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
        }
        private class DependencyObject
        {
            private readonly bool isSinglton;
            public DependencyObject(Type concreteType, bool isSingleton, object instance)
            {
                this.isSinglton = isSingleton;
                this.ConcreteType = concreteType;
                this.SingletonInstance = instance;
            }
            public Type ConcreteType { get; private set; }
            public object SingletonInstance { get; private set; }
            public object CreateInstance(params object[] args)
            {
                object instance = Activator.CreateInstance(ConcreteType, args);
                if (isSinglton)
                    SingletonInstance = instance; return instance;
            }
        }
    }
}

