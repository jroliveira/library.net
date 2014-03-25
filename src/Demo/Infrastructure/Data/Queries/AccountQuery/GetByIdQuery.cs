using System;
using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.AccountQuery {

    public class GetByIdQuery : IQuery<Account, long> {

        private readonly dynamic _database;

        public GetByIdQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult(long id) {
            throw new NotImplementedException();
        }
    }
}
