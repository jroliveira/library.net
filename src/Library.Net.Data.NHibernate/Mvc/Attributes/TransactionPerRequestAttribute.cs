using System;
using System.Data;
using System.Web.Mvc;
using Library.Net.IoC;
using NHibernate;

namespace Library.Net.Data.NHibernate.Mvc.Attributes {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TransactionPerRequestAttribute : ActionFilterAttribute {

        private readonly IsolationLevel _isolationLevel;
        private ISession _session;
        private ITransaction _transaction;

        public TransactionPerRequestAttribute(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted) {
            _isolationLevel = isolationLevel;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            _session = DependencyContainerHelper.Get<ISession>();
            _transaction = _session.BeginTransaction(_isolationLevel);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            if (filterContext.Exception == null)
                _transaction.Commit();
            else
                _transaction.Rollback();
        }
    }
}
