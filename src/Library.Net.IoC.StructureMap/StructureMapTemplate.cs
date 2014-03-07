using System;
using StructureMap;

namespace Library.Net.IoC.StructureMap {

    public abstract class StructureMapTemplate : IDependencyContainer {

        protected IContainer Container;

        public T Get<T>() {
            return Container.GetInstance<T>();
        }

        public object Get(Type type) {
            return Container.GetInstance(type);
        }

        public abstract void Configure();
    }
}
