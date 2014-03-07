using System;
using System.Web;

namespace Demo.Web.Lib.Extensions {

    public static class HttpServerUtilityBaseExtension {

        public static string GetRootPath(this HttpServerUtilityBase server) {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}