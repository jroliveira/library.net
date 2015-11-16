using System;

namespace Library.Net.IoC
{
    public static class DependencyContainerHelper
    {
        private static IDependencyContainer _container;

        public static void Init(IDependencyContainer container)
        {
            _container = container;
            _container.Configure();
        }

        public static T Get<T>()
        {
            return _container.Get<T>();
        }

        public static object Get(Type type)
        {
            return _container.Get(type);
        }
    }
}