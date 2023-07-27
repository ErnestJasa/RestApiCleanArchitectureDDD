using MediatR;

using RestApiDDDArchitecture.Domain.MenuAggregate.Events;

namespace RestApiDDDArchitecture.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
