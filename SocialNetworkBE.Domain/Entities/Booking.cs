using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Booking : BaseEntity
{
    public FootballField Field { get; set; }
    public Match Match { get; set; }
    public DateTime ReservationDate { get; set; }
    public decimal TotalPrice { get; set; }
    public Player ReservedBy { get; set; }
    public BookingStatus Status { get; set; }
   
}
