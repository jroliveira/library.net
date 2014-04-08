using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo.Infrastructure.Menu {

    public class RootMenu : BaseMenu {

        public IEnumerable<ItemMenu> Items { get; set; }

        public RootMenu() {
            Items = new Collection<ItemMenu>();
        }

        public bool HasItems() {
            return Items.Any();
        }
    }
}