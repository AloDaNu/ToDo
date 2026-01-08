using OperationResults;

namespace ToDo.Domain.Exceptions;

public class DomainException : ResultException
{
    public DomainException(int type, string message):base(type, message)
    {
    }
}