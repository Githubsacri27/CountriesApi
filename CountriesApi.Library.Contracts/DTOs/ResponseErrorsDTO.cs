
using CountriesApi.XCutting.Enums;


namespace CountriesApi.Library.Contracts.DTOs
{
    public class ResponseErrorsDTO
    {
        public RegisterErrorCodesEnum ErrorCode { get; set; } 
        public string Message { get; set; }  
        public string Details { get; set; } 

        public ResponseErrorsDTO(RegisterErrorCodesEnum errorCode, string message, string details = null)
        {
            ErrorCode = errorCode;
            Message = message;
            Details = details;
        }
    }

}
