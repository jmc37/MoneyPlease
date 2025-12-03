namespace MoneyPlease.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public required string Message { get; set; }

        public static ServiceResult Failure(string message = " ")
        {
            return new ServiceResult
            {
                Success = false,
                Message = message
            };
        }

        public static ServiceResult SuccessResult(string message = " ")
        {
            return new ServiceResult
            {
                Success = true,
                Message = message
            };
        }
    }
    public class ServiceResult<T> : ServiceResult
    {
        public T data { get; set; }
        public static ServiceResult<T> SuccessResult(T data, string message = "")

            => new ServiceResult<T> { Success = true, Message = message, data = data };
    }
}