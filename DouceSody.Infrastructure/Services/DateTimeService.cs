using DouceSody.Application.Common.Interfaces;

namespace DouceSody.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
