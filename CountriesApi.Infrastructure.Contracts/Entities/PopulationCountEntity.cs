using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Contracts.Entities
{
    public class PopulationCountEntity
    {
        public int year { get; set; }
        public long value { get; set; }
    }
}
