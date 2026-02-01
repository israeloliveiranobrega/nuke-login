using System.Text.RegularExpressions;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base;
public record Password
{
    public string Hash { get; init; }

    public Password(string password)
    {
        ValidPassword(password);

        Hash = BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool Validate(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, Hash);
    }

    private void ValidPassword(string password)
    {
        string regexPattern = @"^(?=.*[A-Z])(?=.*\d).{16,}$";

        if (!Regex.IsMatch(password, regexPattern))
            throw new ArgumentException("A senha não atende os requesitos.");
    }
}
