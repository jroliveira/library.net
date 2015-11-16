using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library.Net.IoC.Mvc
{
    public class DependencyContainerControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            return DependencyContainerHelper.Get(controllerType) as Controller;
        }
    }
}
