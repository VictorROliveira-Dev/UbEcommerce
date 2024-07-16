namespace UbEcommerce.API.Application.Responses
{
    public class Response<T>
    {
        private int _code = 200;
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }

        public Response(T data, int code = 200, string? message = null)
        {
            _code = code;
            Message = message;
            Data = data;
        }

    }
}
