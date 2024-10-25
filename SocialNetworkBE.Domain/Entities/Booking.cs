using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Entities;

public class Booking : BaseEntity
{
    public Guid FieldId { get; set; }
    public FootballField Field { get; set; }
    public Guid MatchId { get; set; }

    public Match Match { get; set; }
    public DateTime ReservationDate { get; set; }
    public Guid ReservedById { get; set; }
    public decimal TotalPrice { get; set; }
    public Player ReservedBy { get; set; }
    public BookingStatus Status { get; set; }
   
}
