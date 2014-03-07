using System;
using Demo.Domain.Services;
using Demo.Infrastructure.Data;
using Library.Net.Data;
using Library.Net.IoC;
using StructureMap;

namespace Demo.Infrastructure.IoC {

    public class StructureMapContainer : IDependencyContainer {

        private IContainer _container;

        public T Get<T>() {
            return _container.GetInstance<T>();
        }

        public object Get(Type type) {
            return _container.GetInstance(type);
        }

        public IDependencyContainer Configure() {
            _container = new Container(registry => {
                /* Db Session */


                /* Query Classes */
                registry.For<IQueryFactory>().Use<QueryFactory>();

                /* Domain Services */
                registry.For<IEmailService>().Use<EmailService>();
            });

            return this;
        }
    }
}
