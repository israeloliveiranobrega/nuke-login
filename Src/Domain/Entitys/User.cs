using NukeLogin.Src.Domain.ValueObjects;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Domain.ValueObjects.Base.Enums;

namespace NukeLogin.Src.Domain.Entitys;

public record User : BaseMetaData
{
    #region Base Properties
    public Person Person { get; init; }
    public Address Address { get; init; }
    public Email Email { get; init; }
    public Phone? Phone { get; init; }
    public Password Password { get; init; }
    public AccountStatus Status { get; init; }
    #endregion

    #region Person geters
    public string FirstName => Person.FirstName;
    public string LastName => Person.LastName;
    public string FullName => Person.FullName; //ef - ignore

    public DateOnly BirthDate => Person.BirthDate;

    public string Numbers => Person.Cpf.Numbers; //ef - ignore
    public string Validators => Person.Cpf.Validators; //ef - ignore
    public string UnformattedCpf => $"{Numbers}{Validators}"; 
    public string FormattedCpf => Person.Cpf.FormattedCpf; //ef - ignore
    public string MaskedCpf => $"{FormattedCpf.Split('.')[0]}.XXX.XXX-{FormattedCpf.Split('-')[1]}"; //ef - ignore
    #endregion

    #region Address geters
    public string AddressZipCode => Address.ZipCode;
    public string AddressRegion => Address.Region;
    public string AddressState => Address.State;
    public string AddressCity => Address.City;
    public string AddressNeighborhood => Address.Neighborhood;
    public string AddressStreet => Address.Street;
    public string? AddressNumber => Address.Number;
    public string? AddressComplement => Address.Complement;
    public string FullAddress => Address.FullAddress; //ef - ignore
    #endregion

    #region Email geters
    public string EmailAddress => Email.Address;
    public string EmailDomain => Email.Domain;
    public string FullEmail => Email.FullEmail; //ef - ignore
    public string MaskedEmail => Email.MaskedEmail; //ef - ignore
    #endregion

    #region Phone geters
    public ulong? PhoneCountryCode => Phone?.CountryCode;
    public ulong? PhoneNumber => Phone?.Number;
    public ulong? FullPhone => Phone?.FullPhone; //ef - ignore
    public string? UnformattedNumber => Phone?.UnformattedNumber; //ef - ignore;
    public string? FormattedPhone => Phone?.FormattedNumber; //ef - ignore
    public string? MaskedPhone => Phone?.MaskedPhone; //ef - ignore
    #endregion

    #region Password geters
    public string PasswordHash => Password.Hash;
    #endregion

    private User() { }

    public User(Person person, Address address, Email email, Password password, Phone? phone, AccountStatus status = AccountStatus.Pending)
    {
        Person = person;
        Address = address;
        Email = email;
        Phone = phone;
        Password = password;
        Status = status;
    }
}
