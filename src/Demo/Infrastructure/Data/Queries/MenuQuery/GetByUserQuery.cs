using System.Collections.Generic;
using System.Collections.ObjectModel;
using Demo.Infrastructure.Menu;
using Library.Net.Data;

namespace Demo.Infrastructure.Data.Queries.MenuQuery {

    public class GetByUserQuery : IQuery<IEnumerable<BaseMenu>, string> {

        private readonly dynamic _database;

        public GetByUserQuery(dynamic database) {
            _database = database;
        }

        public virtual IEnumerable<BaseMenu> GetResult(string user) {
            return new Collection<BaseMenu> {
                new RootMenu { Name = "Cadastrar", CssClass = "glyphicon glyphicon-plus", Items = new Collection<ItemMenu> {
                    new ItemMenu { Action = "Index", Controller = "Page", Name = "Página", CssClass = "glyphicon glyphicon-file" }}},
                new ItemMenu { Action = "Index", Controller = "Page", Name = "Página", CssClass = "glyphicon glyphicon-file" }
            };
        }
    }
}
