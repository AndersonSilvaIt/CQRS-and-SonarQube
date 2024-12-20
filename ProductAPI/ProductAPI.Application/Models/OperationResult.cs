namespace ProductAPI.Application.Models
{
    public class OperationResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }
        public object Data { get; private set; }

        public static OperationResult Ok(string message = "Operation with success", object data = null)
        {
            return new OperationResult { Success = true, Message = message, Data = data };
        }

        public static OperationResult Fail(string message, List<string> errors = null)
        {
            return new OperationResult { Success = false, Message = message, Errors = errors ?? new List<string>() };
        }
    }
}