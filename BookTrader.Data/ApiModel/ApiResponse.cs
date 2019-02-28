namespace BookTrader.Data.ApiModel
{
    /// <summary>
    /// the api response model (result != null or error)
    /// </summary>
    /// <typeparam name="T">the result type</typeparam>
    public class ApiResponse<T>
    {
        /// <remarks/>
        public ApiResponse(T result)
        {
            this.Result = result;
        }


        /// <remarks/>
        public ApiResponse(string code, string message)
        {
            this.Error = new ErrorResponse { Code = code, Message = message };

        }

        /// <remarks/>
        public ApiResponse(ErrorResponse error)
        {
            this.Error = error;
        }


        /// <remarks/>
        public ApiResponse()
        {

        }

        /// <remarks/>
        public T Result { get; }

        /// <remarks/>
        public ErrorResponse Error { get; set; }
    }
}