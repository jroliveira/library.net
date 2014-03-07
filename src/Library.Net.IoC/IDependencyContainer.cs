using System;

namespace Library.Net.IoC {

    public interface IDependencyContainer {

        T Get<T>();
        object Get(Type type);
        void Configure();
    }
}
