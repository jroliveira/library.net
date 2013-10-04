using System;
using System.Web.Mvc;
using Library.Net.Data.NHibernate.Factories;
using Library.Net.IoC;
using NHibernate;
using NHibernate.Context;

namespace Library.Net.Data.NHibernate.Mvc.Attributes {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class NHibernateSessionAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!CurrentSessionContext.HasBind(SessionFactoryFactory.Instance.CurrentSessionFactory)) {
                CurrentSessionContext.Bind(DependencyContainerHelper.Get<ISession>());
            }
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var currentSession = CurrentSessionContext.Unbind(SessionFactoryFactory.Instance.CurrentSessionFactory);
            if (currentSession == null) return;
            currentSession.Close();
            currentSession.Dispose();
        }
    }
}
