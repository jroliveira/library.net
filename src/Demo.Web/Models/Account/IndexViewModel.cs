using System.Collections.Generic;
using System.Collections.ObjectModel;
using Library.Net.Mvc.Models;

namespace Demo.Web.Models.Account {

    public class IndexViewModel :DefaultViewModel {

        public IEnumerable<AccountViewModel> Accounts { get; set; }

        public IndexViewModel() {
            Accounts = new Collection<AccountViewModel>();
        }

        protected override string MenuSelected {
            get { return "accountlist"; }
        }
    }
}