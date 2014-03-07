using System;
using System.Web.Mvc;
using System.Web.Routing;
using Library.Net.IoC;

namespace Demo.Web.App_Start {

    public class StructureMapControllerFactory : DefaultControllerFactory {

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            if (controllerType == null) return null;

            return DependencyContainerHelper.Get(controllerType) as Controller;
        }
    }
}