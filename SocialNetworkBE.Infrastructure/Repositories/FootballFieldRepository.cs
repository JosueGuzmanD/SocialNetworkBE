using Microsoft.EntityFrameworkCore;
using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;
using SocialNetworkBE.Domain.Repositories;

namespace SocialNetworkBE.Infrastructure.Repositories;

public class FootballFieldRepository : GenericRepository<FootballField>, IFootballFieldRepository
{
    public FootballFieldRepository(SocialNetworkDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FootballField>> SearchByNameAsync(string name)
    {
        return await _context.FootballFields
            .Where(f => f.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<IEnumerable<FootballField>> GetByTypeAndCapacityAsync(FieldType? fieldType = null,
        FieldCapacity? fieldCapacity = null)
    {
        return await _context.FootballFields
            .Where(f => f.FieldType == fieldType && f.FieldCapacity == fieldCapacity)
            .ToListAsync();
    }

    public async Task<IEnumerable<FootballField>> GetByPriceRangeAsync(double minPrice, double maxPrice)
    {
        return await _context.FootballFields
            .Where(f => f.PricePerHour >= minPrice && f.PricePerHour <= maxPrice)
            .ToListAsync();
    }

    public async Task<IEnumerable<FootballField>> GetByCityAsync(string city)
    {
        return await _context.FootballFields
            .Where(f => f.Address.City == city)
            .ToListAsync();
    }

    public async Task<IEnumerable<FootballField>> GetByPostalCodeAsync(string postalCode)
    {
        return await _context.FootballFields
            .Where(f => f.Address.PostalCode == postalCode)
            .ToListAsync();
    }

    public async Task<IEnumerable<FootballField>> GetAvailableFieldsByDateAsync(DateTime date)
    {
        return await _context.FootballFields
            .Where(f => f.Bookings.All(b => b.ReservationDate.Date != date.Date))
            .ToListAsync();
    }
}