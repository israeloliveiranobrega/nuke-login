using NukeLogin.Src.Shared.Exceptions;
using NukeLogin.Src.Shared.Extension;
using static NukeLogin.Src.Shared.Extension.StringExtensionHelper;

namespace NukeLogin.Src.Domain.ValueObjects.Base;
public record Phone
{
    public ulong CountryCode { get; init; }
    public ulong Number { get; init; }

    public ulong FullPhone => ulong.Parse($"{CountryCode}{Number}");
    public string UnformattedNumber => $"{CountryCode}{Number}";
    public string FormattedNumber => $"({CountryCode}) {UnformattedNumber[2]} {UnformattedNumber[3..7]}-{UnformattedNumber[7..11]}";
    public string MaskedPhone => $"({CountryCode}) * ****-**{FormattedNumber[^2..]}";

    private Phone() { }

    public Phone(ulong countryCode, ulong number)
    {
        ValidCountryCode(countryCode.ToString());
        ValidNumber(number.ToString());

        CountryCode = countryCode;
        Number = number;
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
