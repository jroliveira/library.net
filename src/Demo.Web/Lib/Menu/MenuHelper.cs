using System;
using System.Collections.Generic;
using System.Configuration;
using Demo.Infrastructure.Data.Queries.MenuQuery;
using Demo.Infrastructure.Menu;
using Library.Net.Cache;
using Library.Net.IoC;

namespace Demo.Web.Lib.Menu {

    public class MenuHelper {

        public int MyProperty { get; set; }
        private static readonly int CacheMenuInMinutes = Convert.ToInt32(ConfigurationManager.AppSettings["cache.menu.in.minutes"]);

        private static ICacheProvider _cacheProvider = new MemoryCacheProvider();
        public void SetCacheProvider(ICacheProvider cacheProvider) {
            _cacheProvider = cacheProvider;
        }

        private static GetByUserQuery _query = DependencyContainerHelper.Get<GetByUserQuery>();
        public void SetQuery(GetByUserQuery query) {
            _query = query;
        }

        public static IEnumerable<MenuItem> GetBy(string user) {
            if (_cacheProvider.IsSet(user))
                return _cacheProvider.Get(user) as IEnumerable<MenuItem>;

            var menu = _query.GetResult(user);
            _cacheProvider.Set(user, menu, CacheMenuInMinutes);

            return menu;
        }
    }
}