using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.Infrastructure.Contracts.Entities
{
    public class ApiResponseEntity
    {
        public bool error { get; set; }
        public string msg { get; set; }
        public List<CountryEntity> data { get; set; }
    }
}
