using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.Infrastructure.Menu;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.MenuQuery {
    
    public class GetByUserQuery : IQuery<IEnumerable<MenuItem>, string> {

        private readonly dynamic _database;

        public GetByUserQuery(dynamic database) {
            _database = database;
        }

        public virtual IEnumerable<MenuItem> GetResult(string user) {
            return new Collection<MenuItem> {
                new MenuItem { Name = "Cadastrar", Class = "glyphicon glyphicon-plus", Items = new Collection<MenuItem> {
                    new MenuItem { Action = "Index", Controller = "Page", Name = "Página", Class = "glyphicon glyphicon-file" }}}
            };
        }
    }
}
