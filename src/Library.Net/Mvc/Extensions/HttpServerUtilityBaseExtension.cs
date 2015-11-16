using System;
using System.Web;

namespace Library.Net.Mvc.Extensions
{
    public static class HttpServerUtilityBaseExtension
    {
        public static string GetRootPath(this HttpServerUtilityBase server)
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}