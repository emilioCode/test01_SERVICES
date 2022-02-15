using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace test01_SERVICES.Utils
{
    public class ConnectionString
    {
        public static string server { get; set; }
        public static string database { get; set; }
        public static string user { get; set; }
        public static string password { get; set; }
        public static string Init()
        {
            return $"server={ server };uid={ user };pwd={ password };database={ database }";
        }
    }
}
