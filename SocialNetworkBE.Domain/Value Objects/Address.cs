namespace SocialNetworkBE.Domain.Value_Objects;

public class Address
{
    public Address(string street, string city, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Street cannot be empty");
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("City cannot be empty");
        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentException("PostalCode cannot be empty");
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Country cannot be empty");

        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }
}