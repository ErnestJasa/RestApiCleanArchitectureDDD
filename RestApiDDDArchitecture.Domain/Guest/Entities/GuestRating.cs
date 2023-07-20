using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Guest.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDDDArchitecture.Domain.Guest.Entities
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
