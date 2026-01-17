using ToDo.Application.Dtos;
using ToDo.Domain.Entities;

namespace ToDo.Application.Abstractions.Services;

public interface ITaskQueryService
{
    IReadOnlyCollection<TaskDto> Get();
}