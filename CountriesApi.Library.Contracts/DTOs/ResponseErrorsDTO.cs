
using CountriesApi.XCutting.Enums;


namespace CountriesApi.Library.Contracts.DTOs
{
    public class ResponseErrorsDTO
    {
        public RegisterErrorCodesEnum ErrorCode { get; set; }  // Usa el enum para estandarizar el código de error
        public string Message { get; set; }        // Mensaje detallado del error
        public string Details { get; set; }        // Información adicional opcional

        public ResponseErrorsDTO(RegisterErrorCodesEnum errorCode, string message, string details = null)
        {
            ErrorCode = errorCode;
            Message = message;
            Details = details;
        }
    }

}
