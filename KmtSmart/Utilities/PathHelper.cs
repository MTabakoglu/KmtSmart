using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmtSmart.Utilities
{
    public static class PathHelper
    {
        //static string ServerUrl = "http://46.45.185.125:57160/api/";

        private static string ServerUrl = "https://localhost:44373/api/";
        public static string GetApiServerPath(string ControllerName, string functionName)
        {
            return ServerUrl + ControllerName + "/" + functionName;
        }
        public static string GetApiServerPath(string ControllerName, string functionName, string ParameterName, int Id)
        {
            return ServerUrl + ControllerName + "/" + functionName + "?" + ParameterName + "=" + Id.ToString();
        }
    }
}
