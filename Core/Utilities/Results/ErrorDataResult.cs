namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, success: false)
        {
        }

        public ErrorDataResult(T data, object message) : base(data, success: false, message)
        {
        }
        public ErrorDataResult(object message) : base(default, success: false, message)
        {
        }
    }
}
