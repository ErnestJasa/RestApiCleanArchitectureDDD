using RestApiDDDArchitecture.Domain.Common.Models;

namespace RestApiDDDArchitecture.Domain.MenuAggregate.Events;

public record MenuCreated(Menu menu) : IDomainEvent;