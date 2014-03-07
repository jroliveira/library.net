using Demo.Domain.Services;
using Demo.Infrastructure.Data;
using Library.Net.Data;
using Library.Net.IoC.StructureMap;
using StructureMap;

namespace Demo.Infrastructure.IoC {

    public class StructureMapContainer : StructureMapTemplate {

        public override void Configure() {
            Container = new Container(registry => {
                /* Db Session */


                /* Query Classes */
                registry.For<IQueryFactory>().Use<QueryFactory>();

                /* Domain Services */
                registry.For<IEmailService>().Use<EmailService>();
            });
        }
    }
}
