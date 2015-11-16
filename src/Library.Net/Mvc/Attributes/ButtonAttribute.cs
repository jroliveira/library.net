using System.Reflection;
using System.Web.Mvc;

namespace Library.Net.Mvc.Attributes
{
    public class ButtonAttribute : ActionMethodSelectorAttribute
    {
        public string Name { get; set; }

        public ButtonAttribute(string name)
        {
            Name = name;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.Controller.ValueProvider.GetValue(Name) != null;
        }
    }
}