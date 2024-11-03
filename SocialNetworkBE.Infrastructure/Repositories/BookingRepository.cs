using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Interfaces.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(SocialNetworkDbContext context) : base(context)
    {
    }


    public async Task<IEnumerable<Booking>> GetBookingsByPlayerIdAsync(Guid playerId)
    {
        return await _context.Bookings
            .Where(b => b.ReservedBy.Id == playerId)
            .Include(b => b.Field)
            .Include(b => b.Match)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetBookingsByFieldandDateAsync(Guid fieldId, DateTime date)
    {
        return await _context.Bookings
            .Where(b => b.Field.Id == fieldId && b.CreationDate == date.Date)
            .Include(b => b.ReservedBy)
            .Include(b => b.Match)
            .ToListAsync();
    }
}