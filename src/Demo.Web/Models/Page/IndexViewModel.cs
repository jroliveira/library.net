using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Net.Mvc.Models;

namespace Demo.Web.Models.Page {

    public class IndexViewModel : DefaultViewModel {

        public IEnumerable<PageViewModel> Pages { get; set; }

        public IndexViewModel() {
            Pages = new Collection<PageViewModel>();
        }

        protected override string MenuSelected {
            get { return "pagelist"; }
        }
    }
}