﻿using RestApiDDDArchitecture.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDDDArchitecture.Domain.DinnerAggregate.ValueObjects
{
    public sealed class Location : ValueObject
    {
        public string Name { get; }
        public string Address { get; }
        public float Latitude { get; }
        public float Longitude { get; }
        private Location(string name, string address, float latitude, float longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }
        public static Location Create(string name, string address, float latitude, float longitude)
        {
            return new(name, address, latitude, longitude);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Address;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
