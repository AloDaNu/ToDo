using ToDo.Application.Abstractions.Providers;

namespace ToDo.Application.Providers;

public class TimeProvider : ITimeProvider
{
    public long NowUnix()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    public DateTime NowDateTime()
    {
        return DateTime.UtcNow;
    }
}