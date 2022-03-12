using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestGraphQL
{
    public class LaunchesPast
    {
        public string mission_name { get; set; }
    }

    public class Data
    {
        public List<LaunchesPast> launchesPast { get; set; }
    }
}
