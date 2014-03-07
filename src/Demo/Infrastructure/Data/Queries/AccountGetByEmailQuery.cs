using System;
using Demo.Domain.Entities;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries {

    public class AccountGetByEmailQuery : IQuery<Account> {

        private readonly dynamic _database;

        public string Email { get; set; }

        public AccountGetByEmailQuery(dynamic database) {
            _database = database;
        }

        public virtual Account GetResult() {
            throw new NotImplementedException();
        }
    }
}
