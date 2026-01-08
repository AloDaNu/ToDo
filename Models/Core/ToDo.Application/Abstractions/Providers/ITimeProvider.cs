namespace ToDo.Application.Abstractions.Providers;

public interface ITimeProvider
{
    long NowUnix();
    
    DateTime NowDateTime();
}