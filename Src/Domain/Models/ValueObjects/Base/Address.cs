using NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
using NukeLogin.Src.UseCases.Extension;
using static NukeLogin.Src.UseCases.Extension.StringExtensionHelper;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base;
public record Address
{
    public string ZipCode { get; init; }
    public string Region { get; init; }
    public string State { get; init; }
    public string City { get; init; }
    public string Neighborhood { get; init; }
    public string Street { get; init; }
    public string? Number { get; init; }
    public string? Complement { get; init; }
    public string FullAddress
    {
        get
        {
            var fullAddress = $"{Street}";

            if (!string.IsNullOrEmpty(Number))
                fullAddress += $", {Number}";

            if (!string.IsNullOrEmpty(Complement))
                fullAddress += $", {Complement}";

            fullAddress += $", {Neighborhood}, {City} - {State}, CEP: {ZipCode}";
            return fullAddress;
        }
    }

    public Address(string postalCode, string region, string state, string city,
    string district, string street, string? number, string? complement)
    {
        ValidatePostalCode(postalCode);

        if (number != null)
            ValidateNumber(number);

        foreach (var str in new string[] { region, state, city, district, street })
        {
            ValidateAddressFormar(str);
        }

        ZipCode = postalCode;
        Region = region;
        State = state;
        City = city;
        Neighborhood = district;
        Street = street;
        Number = number;
        Complement = complement;
    }

    private void ValidatePostalCode(string postalCode)
    {
        if (!postalCode.IsOnlyLettersOrNumbers(CheckType.OnlyNumbers) || !postalCode.HasLength(8))
            throw new InvalidPostalCodeFormatException();
    }
    private void ValidateNumber(string number)
    {
        if (!number.IsOnlyLettersOrNumbers(CheckType.OnlyNumbers) || int.Parse(number) <= 0)
            throw new InvalidNumberFormatException();
    }
    private void ValidateAddressFormar(string str)
    {
        if (!str.HasContent() || !str.HasMinLength(3))
            throw new ArgumentException(nameof(str));
    }
}
