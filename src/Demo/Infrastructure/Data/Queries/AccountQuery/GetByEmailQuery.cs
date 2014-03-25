using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.AccountQuery {

    public class GetByEmailQuery : IQuery<Account, string> {

        private readonly dynamic _database;

        public GetByEmailQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult(string email) {
            return new Account("junolive@gmail.com", "legal");
        }
    }
}
