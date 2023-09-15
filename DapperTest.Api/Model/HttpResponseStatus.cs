namespace DapperTest.Api.Model
{
    public static class HttpResponseStatus
    {
        public static ApiResponseStatus OK => new ApiResponseStatus
        {
            Code = 200,
            Description = "OK"
        };

        public static ApiResponseStatus BadRequest => new ApiResponseStatus
        {
            Code = 400,
            Description = "Bad Request"
        };

        public static ApiResponseStatus InternalServerError => new ApiResponseStatus
        {
            Code = 500,
            Description = "Internal Server Error"
        };
    }
}
