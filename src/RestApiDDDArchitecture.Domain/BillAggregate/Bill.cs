using RestApiDDDArchitecture.Domain.BillAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;

namespace RestApiDDDArchitecture.Domain.BillAggregate
{
    public sealed class Bill : AggregateRoot<BillId, Guid>
    {
        public DinnerId DinnerId { get; }
        public GuestId GuestId { get; }
        public HostId HostId { get; }
        public Price Price { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }
        private Bill(BillId billId,
                     DinnerId dinnerId,
                     GuestId guestId,
                     HostId hostId,
                     Price price,
                     DateTime createdDateTime,
                     DateTime updatedDateTime) : base(billId)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
        {
            return new(BillId.CreateUnique(),
                       dinnerId,
                       guestId,
                       hostId,
                       price,
                       DateTime.UtcNow,
                       DateTime.UtcNow);
        }

    }
}
