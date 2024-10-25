
namespace SocialNetworkBE.Domain;

public class Password
{
    public string Hash { get; set; }


    public Password(string plainTextPassword)
    {
        if (string.IsNullOrEmpty(plainTextPassword))
        {
            throw new ArgumentException("Password cannot be null or empty.");
        }

        // Validar la complejidad de la contraseña
        ValidatePasswordComplexity(plainTextPassword);

        // Hashear la contraseña
        Hash = HashPassword(plainTextPassword);
    }

    private void ValidatePasswordComplexity(string plainTextPassword)
    {
        // Reglas de validación: longitud mínima de 8 caracteres, debe tener letras y números
        if (plainTextPassword.Length < 8 ||
            !plainTextPassword.Any(char.IsLetter) ||
            !plainTextPassword.Any(char.IsDigit))
        {
            throw new ArgumentException("Password must be at least 8 characters long and contain both letters and numbers.");
        }
    }

    // Método privado para hashear la contraseña utilizando BCrypt
    private string HashPassword(string plainTextPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
    }

    // Método público para verificar si una contraseña en texto plano coincide con el hash almacenado
    public bool Verify(string plainTextPassword)
    {
        if (string.IsNullOrEmpty(plainTextPassword))
        {
            throw new ArgumentException("Password cannot be null or empty.");
        }

        return BCrypt.Net.BCrypt.Verify(plainTextPassword, Hash);
    }

    // Sobreescribimos Equals y GetHashCode para comparar correctamente los objetos Password
    public override bool Equals(object obj)
    {
        if (obj is Password other)
        {
            return Hash == other.Hash;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Hash.GetHashCode();
    }

}
