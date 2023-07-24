using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuReviewAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.MenuReviewAggregate;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
    public int Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private MenuReview(MenuReviewId menuReviewId,
                       int rating,
                       string comment,
                       HostId hostId,
                       MenuId menuId,
                       GuestId guestId,
                       DinnerId dinnerId,
                       DateTime createdDateTime,
                       DateTime updatedDateTime) : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static MenuReview Create(int rating,
                                    string comment,
                                    HostId hostId,
                                    MenuId menuId,
                                    GuestId guestId,
                                    DinnerId dinnerId)
    {
        return new MenuReview(MenuReviewId.CreateUnique(),
                              rating,
                              comment,
                              hostId,
                              menuId,
                              guestId,
                              dinnerId,
                              DateTime.UtcNow,
                              DateTime.UtcNow);
    }
}