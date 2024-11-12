using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Library.Domain
{
    public class Rootobject
    {
        public bool error { get; set; }
        public string msg { get; set; }
        public Datum[] data { get; set; }
    }
}
