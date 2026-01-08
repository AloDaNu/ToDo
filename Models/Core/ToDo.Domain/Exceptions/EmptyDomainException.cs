using OperationResults;

namespace ToDo.Domain.Exceptions;

public class EmptyDomainException : DomainException
{
    public EmptyDomainException(string message):base(ResultErrorTypes.NullOrEmpty, message)
    {
        
    }
}