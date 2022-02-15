using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test01_SERVICES.Models.Data
{
    public class genericJsonResponse
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = "";
        public object data { get; set; } = null;

    }
}
