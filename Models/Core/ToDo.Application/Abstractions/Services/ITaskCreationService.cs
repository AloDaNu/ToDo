namespace ToDo.Application.Abstractions.Services;

public interface ITaskCreationService
{
    void Create(string title, string description, long? deadline);
}