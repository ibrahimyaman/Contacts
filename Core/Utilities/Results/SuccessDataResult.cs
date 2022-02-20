namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, success:true)
        {
        }

        public SuccessDataResult(T data, object message) : base(data, success:true, message)
        {
        }
        public SuccessDataResult(object message) : base(default, success: true, message)
        {
        }
    }
}
