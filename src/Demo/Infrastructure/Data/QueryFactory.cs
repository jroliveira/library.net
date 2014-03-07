using Library.Net.Data;
using Library.Net.IoC;

namespace Demo.Infrastructure.Data {

    public class QueryFactory : IQueryFactory {

        public TQuery CreateQuery<TQuery>()
            where TQuery : IQuery {
            return DependencyContainerHelper.Get<TQuery>();
        }
    }
}
