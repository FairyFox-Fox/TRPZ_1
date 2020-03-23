using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjectionService
{
    internal class DependencyObject
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
