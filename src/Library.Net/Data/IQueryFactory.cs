namespace Library.Net.Data {

    public interface IQueryFactory {

        TQuery CreateQuery<TQuery>()
            where TQuery : IQuery;
    }
}