using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo.Infrastructure.Menu {

    public class MenuItem {

        public string Name { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Class { get; set; }
        public IEnumerable<MenuItem> Items { get; set; }

        public MenuItem() {
            Items = new Collection<MenuItem>();
        }

        public bool HasItems() {
            return Items.Any();
        }
    }
}