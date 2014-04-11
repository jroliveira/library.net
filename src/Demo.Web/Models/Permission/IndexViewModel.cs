using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo.Web.Models.Permission {

    public class IndexViewModel {

        public long AccountId { get; set; }
        public IEnumerable<PageViewModel> Pages { get; set; }

        public IndexViewModel() {
            Pages = new Collection<PageViewModel>();
        }
    }
}