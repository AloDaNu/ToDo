using OperationResults;

namespace ToDo.Application.Abstractions.Features;

public interface ITaskCreateFeature
{
    Result Create(string title, string description, long? deadline);
}