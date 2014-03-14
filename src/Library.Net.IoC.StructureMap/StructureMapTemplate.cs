using System;
using StructureMap;

namespace Library.Net.IoC.StructureMap {

    public abstract class StructureMapTemplate : IDependencyContainer {

        private IContainer _container;

        public T Get<T>() {
            return _container.GetInstance<T>();
        }

        public object Get(Type type) {
            return _container.GetInstance(type);
        }

        public void Configure() {
            _container = ConfigureDependencies();
        }

        protected abstract IContainer ConfigureDependencies();
    }
}
