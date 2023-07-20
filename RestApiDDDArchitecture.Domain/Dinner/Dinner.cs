using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Dinner.Entities;
using RestApiDDDArchitecture.Domain.Dinner.Enums;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;
using RestApiDDDArchitecture.Domain.Menu.ValueObjects;

namespace RestApiDDDArchitecture.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime? StartedDateTime { get; } = null;
    public DateTime? EndedDateTime { get; } = null;
    public DinnerStatus DinnerStatus { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    private Dinner(DinnerId dinnerId,
                   string name,
                   string description,
                   DateTime startDayTime,
                   DateTime endDateTime,
                   DateTime? startedDayTime,
                   DateTime? endedDayTime,
                   DinnerStatus dinnerStatus,
                   bool isPublic,
                   int maxGuests,
                   Price price,
                   HostId hostId,
                   MenuId menuId,
                   string imageUrl,
                   Location location,
                   DateTime createdDateTime,
                   DateTime updatedDayTime) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDayTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDayTime;
        EndedDateTime = endedDayTime;
        DinnerStatus = dinnerStatus;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDayTime;
    }

    public static Dinner Create(string name,
                   string description,
                   DateTime startDayTime,
                   DateTime endDateTime,
                   bool isPublic,
                   int maxGuests,
                   Price price,
                   HostId hostId,
                   MenuId menuId,
                   string imageUrl,
                   Location location)
    {
        
        return new Dinner(DinnerId.CreateUnique(),
                          name,
                          description,
                          startDayTime,
                          endDateTime,
                          null,
                          null,
                          0,
                          isPublic,
                          maxGuests,
                          price,
                          hostId,
                          menuId,
                          imageUrl,
                          location,
                          DateTime.UtcNow,
                          DateTime.UtcNow);
    }

}