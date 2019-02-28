using System;

namespace BookTrader.Data.ApiModel
{
    /// <summary>
    /// The error response with code that can be translated in SPA client like VueJS or Angular
    /// </summary>
    public class ErrorResponse
    {

        /// <remarks/>
        public ErrorResponse() {  }

        /// <remarks/>
        private ErrorResponse(string code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// the error code 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// the error message
        /// </summary>
        public string Message { get; set; }
        
        public static ErrorResponse LoginFailed =>
            new ErrorResponse("login.failed", "email or password invalid");

        public static ErrorResponse NoReady =>
            new ErrorResponse("not.implemented", "not implemented yet!!");

        public static ErrorResponse InvalidParams =>
            new ErrorResponse("wrong.params", "params invalid");

        public static ErrorResponse InternalServiceError =>
            new ErrorResponse("internal.service.error", "internal service error");
        
        public static ErrorResponse UnauthorizedAccess =>
            new ErrorResponse("unauthorized.access", "unauthorized access");

        public static ErrorResponse FieldCanNotBeNullOrEmpty(String field)
        {
            return new ErrorResponse(field + ".null.or.empty", $"{field} field can not be null or empty");
        }
        
        public static ErrorResponse DemoAuthNotSetup =>
            new ErrorResponse("demo.auth.not.setup", "demo authorization not setup");
        
        public static ErrorResponse PriceCanNotBeLessThenZero => 
            new ErrorResponse("price.can.not.be.less.then.zero", "price can't be less then zero");

        public static ErrorResponse NotFound =>
            new ErrorResponse("item.not.found", "item not found");
    }
}