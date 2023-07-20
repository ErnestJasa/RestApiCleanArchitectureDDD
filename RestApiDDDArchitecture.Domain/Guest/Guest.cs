using RestApiDDDArchitecture.Domain.Bill.ValueObjects;
using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Common.ValueObjects;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Guest.Entities;
using RestApiDDDArchitecture.Domain.Guest.ValueObjects;
using RestApiDDDArchitecture.Domain.Host.ValueObjects;
using RestApiDDDArchitecture.Domain.MenuReview.ValueObjects;
using RestApiDDDArchitecture.Domain.User.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDDDArchitecture.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds= new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<GuestRating> _ratings = new();

        public string FirstName { get; }
        public string LastName { get; }
        public string ProfileImage { get; }
        public AverageRating AverageRating { get; set; }
        public UserId UserId { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<GuestRating> Ratings => _ratings.AsReadOnly();

        private Guest(GuestId guestId,
                string firstName,
                string lastName,
                string profilePicture,
                AverageRating averageRating,
                UserId userId,
                DateTime createdDateTime,
                DateTime updatedDateTime) :base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profilePicture;
            AverageRating = averageRating;
            UserId = userId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(string firstName,
                                   string lastName,
                                   string profilePicture,
                                   UserId userId)
        {
            return new(GuestId.CreateUnique(),
                       firstName,
                       lastName,
                       profilePicture,
                       AverageRating.CreateNew(),
                       userId,
                       DateTime.UtcNow,
                       DateTime.UtcNow);
        }
    }
}
