using DouceSody.Domain.Common;

namespace DouceSody.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
