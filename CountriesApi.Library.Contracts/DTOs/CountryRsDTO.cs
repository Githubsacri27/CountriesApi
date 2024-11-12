using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Library.Contracts.DTOs
{
    public class CountryRsDTO
    {

        public bool error { get; set; }
        public string msg { get; set; }
        public DatumDto[] data { get; set; }

    }
}
