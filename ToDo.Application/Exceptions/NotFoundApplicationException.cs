using OperationResults;

namespace ToDo.Application.Exceptions;

public class NotFoundApplicationException : ApplicationException
{
    public NotFoundApplicationException(string message) : 
        base(ResultErrorTypes.NotFound, message)
    {
    }
}