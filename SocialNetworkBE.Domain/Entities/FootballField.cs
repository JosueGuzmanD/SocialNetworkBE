﻿
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Value_Objects;

namespace SocialNetworkBE.Domain.Entities;

public class FootballField : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public Address Address { get; set; }
    public FieldType FieldType { get; set; }
    public FieldCapacity FieldCapacity { get; set; }
    public decimal PricePerHour { get; set; }
    public string ImageUrl { get; set; }
    public List<Booking> Bookings { get; set; }= new List<Booking>();
}

