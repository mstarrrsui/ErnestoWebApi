namespace Shared.TaskApi.Models
{
    public class ApiResultModel<TResult>
    {
        public bool isSuccess { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public TResult Result { get; set; }

    }
}