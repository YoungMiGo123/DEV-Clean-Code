namespace Clean_Code_Services.Features.Application.Common
{
    public class Response<T> where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess => Errors.Count == 0;
        public List<string> Errors { get; set; } = [];
        public Response()
        {

        }
        public Response(string message, T data)
        {
            Data = data;
            Message = message;
        }
        public static Response<T> Success(string message, T data)
        {
            return new Response<T>(message, data);
        }

        public static Response<T> Error(string message, List<string> errors, T data) 
        {
           return new Response<T> 
           { 
               Message = message, 
               Data = data,
               Errors = errors
           };    
        }

        public static Response<T> Error(string message, List<string> errors)
        {
            return new Response<T>
            {
                Message = message,
                Errors = errors
            };
        }
    }
}
