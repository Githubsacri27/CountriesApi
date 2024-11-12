using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountriesApi.XCutting.Enums
{
    public enum RegisterErrorCodesEnum
    {
        NotFound = 404,
        BadRequest = 400,
        InternalServerError = 500,
        ExternalApiError = 502,
        ValidationError = 422
    }
}
