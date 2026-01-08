using System;

namespace OperationResults
{
    public class ResultException : Exception
    {
        public ResultException(int type, string message):
            base (message)
        {
            Type = type;
        }
        public int Type { get; }

        public Result GetResult()
        {
            return Result.Failure(new ResultError(Type, Message));
        }

        public Result<T> GetResult<T>()
        {
            return Result<T>.Failure(new ResultError(Type, Message));
        }
    }
}