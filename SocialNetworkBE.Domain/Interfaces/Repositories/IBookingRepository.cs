using SocialNetworkBE.Domain.Entities;

namespace SocialNetworkBE.Domain.Interfaces.Repositories;

public interface IBookingRepository : IGenericRepository<Booking>
{
    Task<IEnumerable<Booking>> GetBookingsByPlayerIdAsync(Guid playerId);
    Task<IEnumerable<Booking>> GetBookingsByFieldandDateAsync(Guid fieldId, DateTime date);
}