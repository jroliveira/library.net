using System;
using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries {

    public class AccountGetByIdQuery : IQuery<Account> {

        private readonly dynamic _database;

        public long Id { get; set; }

        public AccountGetByIdQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult() {
            throw new NotImplementedException();
        }
    }
}
