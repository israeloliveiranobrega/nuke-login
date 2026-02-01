using NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
using NukeLogin.Src.UseCases.Extension;
using static NukeLogin.Src.UseCases.Extension.StringExtensionHelper;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base;
public record Phone
{
    public ulong CountryCode { get; init; }
    public ulong Number { get; init; }

    public ulong FullPhone => ulong.Parse($"{CountryCode}{Number}");
    public string UnformattedNumber => $"{CountryCode}{Number}";
    public string FormattedNumber => $"({CountryCode}) {UnformattedNumber[2]} {UnformattedNumber[3..7]}-{UnformattedNumber[7..11]}";
    public string MaskedPhone => $"({CountryCode}) * ****-**{FormattedNumber[^2..]}";

    public Phone(string countryCode, string number)
    {
        ValidCountryCode(countryCode);
        ValidNumber(number);

        CountryCode = ulong.Parse(countryCode);
        Number = ulong.Parse(number);
    }

    private void ValidCountryCode(string countryCode)
    {
        if (!countryCode.HasContent())
            throw new ArgumentNullException(nameof(countryCode));

        if (!countryCode.IsOnlyLettersOrNumbers(CheckType.OnlyNumbers))
            throw new InvalidPhoneCountryCodeFormatExceptions();

        if (!countryCode.HasLength(2))
            throw new InvalidPhoneCountryCodeLengthExceptions();
    }
    private void ValidNumber(string number)
    {
        if (!number.HasContent())
            throw new ArgumentNullException(nameof(number));

        if (!number.IsOnlyLettersOrNumbers(CheckType.OnlyNumbers))
            throw new InvalidPhoneCountryCodeFormatExceptions();

        if (!number.HasLength(9))
            throw new InvalidPhoneCountryCodeLengthExceptions();
    }
}
