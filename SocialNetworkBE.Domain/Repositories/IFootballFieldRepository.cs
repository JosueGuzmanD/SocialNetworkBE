using SocialNetworkBE.Domain.Entities;
using SocialNetworkBE.Domain.Enums;

namespace SocialNetworkBE.Domain.Repositories;

public interface IFootballFieldRepository : IGenericRepository<FootballField>
{
    Task<IEnumerable<FootballField>> SearchByNameAsync(string name);

    Task<IEnumerable<FootballField>> GetByTypeAndCapacityAsync(FieldType? fieldType = null,
        FieldCapacity? fieldCapacity = null);

    Task<IEnumerable<FootballField>> GetByPriceRangeAsync(double minPrice, double maxPrice);
    Task<IEnumerable<FootballField>> GetByCityAsync(string city);
    Task<IEnumerable<FootballField>> GetByPostalCodeAsync(string postalCode);
    Task<IEnumerable<FootballField>> GetAvailableFieldsByDateAsync(DateTime date);
}