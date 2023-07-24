using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.GuestAggregate.ValueObjects;
using RestApiDDDArchitecture.Domain.HostAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDDDArchitecture.Domain.GuestAggregate.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public HostId HostId { get; }
        public DinnerId DinnerId { get; }
        public int Rating { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private GuestRating(GuestRatingId guestRatingId,
                            HostId hostId,
                            DinnerId dinnerId,
                            int rating,
                            DateTime createdDateTime,
                            DateTime updatedDateTime) :base(guestRatingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static GuestRating Create(HostId hostId,
                                         DinnerId dinnerId,
                                         int rating)
        {
            return new(GuestRatingId.CreateUnique(),
                       hostId,
                       dinnerId,
                       rating,
                       DateTime.UtcNow,
                       DateTime.UtcNow);
        }

    }
}
