using System;
using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.AccountQuery {

    public class GetByIdQuery : IQuery<Account> {

        private readonly dynamic _database;

        public long Id { get; set; }

        public GetByIdQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult() {
            throw new NotImplementedException();
        }
    }
}
