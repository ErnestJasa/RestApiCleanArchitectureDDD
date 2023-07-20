﻿using RestApiDDDArchitecture.Domain.Bill.ValueObjects;
using RestApiDDDArchitecture.Domain.Common.Models;
using RestApiDDDArchitecture.Domain.Dinner.Enums;
using RestApiDDDArchitecture.Domain.Dinner.ValueObjects;
using RestApiDDDArchitecture.Domain.Guest.ValueObjects;

namespace RestApiDDDArchitecture.Domain.Dinner.Entities
{
    public sealed class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus ReservationStatus { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; } = null;
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Reservation(ReservationId reservationId,
                            int guestCount,
                            ReservationStatus reservationStatus,
                            GuestId guestId,
                            BillId billId,
                            DateTime? arrivalDateTime,
                            DateTime createdDateTime,
                            DateTime updatedDateTime) : base(reservationId)
        {
            GuestCount = guestCount;
            ReservationStatus = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            ArrivalDateTime = arrivalDateTime;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }
        public static Reservation Create(int guestCount,
                                         ReservationStatus reservationStatus,
                                         GuestId guestId,
                                         BillId billId,
                                         DateTime createdDateTime,
                                         DateTime updatedDateTime)
        {
            return new(ReservationId.CreateUnique(),
                       guestCount,
                       reservationStatus,
                       guestId,
                       billId,
                       null,
                       createdDateTime,
                       updatedDateTime);
        }
    }
}