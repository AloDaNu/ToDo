using OperationResults;

namespace ToDo.Application.Exceptions;

public abstract class ApplicationException : ResultException
{
    protected ApplicationException(int type, string message) : base(type, message)
    {
    }
}