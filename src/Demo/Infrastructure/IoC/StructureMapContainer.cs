using Demo.Domain.Services;
using Demo.Infrastructure.Data;
using Demo.Infrastructure.Data.Queries.PermissionQuery;
using Demo.Infrastructure.Logging;
using Library.Net.Data;
using Library.Net.IoC.StructureMap;
using StructureMap;

namespace Demo.Infrastructure.IoC {

    public sealed class StructureMapContainer : StructureMapTemplate {

        protected override IContainer ConfigureDependencies() {
            return new Container(registry => {
                /* Db Session */


                /* Query Classes */
                registry.For<IQueryFactory>().Use<QueryFactory>();
                registry.For<IHasPermissionQuery>().Use<HasPermissionQuery>();

                /* Domain Services */
                registry.For<IEmailService>().Use<EmailService>();

                /* Infrastructure */
                registry.For<ILogger>().Use<Logger>();
            });
        }
    }
}
