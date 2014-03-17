using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.AccountQuery {

    public class GetByEmailQuery : IQuery<Account> {

        private readonly dynamic _database;

        public string Email { get; set; }

        public GetByEmailQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult() {
            return new Account("junolive@gmail.com", "legal");
        }
    }
}
