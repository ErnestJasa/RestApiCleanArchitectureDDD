using RestApiDDDArchitecture.Domain.Bill.ValueObjects;
using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Guest.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;

namespace RestApiDDDArchitecture.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
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
