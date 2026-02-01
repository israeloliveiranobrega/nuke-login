using NukeLogin.Src.Domain.Models.ValueObjects.Base;
using NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;

namespace NukeLogin.Src.Domain.Models.ValueObjects;
public record Person
{
    public Name Name { get; init; }
    public DateOnly BirthDate { get; init; }
    public CPF Cpf { get; init; }
     
    #region Geters
    public string FirstName => Name.FirstName;
    public string LastName => Name.LastName;
    public string FullName => Name.FullName;

    public ulong Numbers => Cpf.Numbers;
    public ulong Validators => Cpf.Validators;
    public ulong BruteCpf => Cpf.BruteCpf;
    public string UnformattedCpf => Cpf.UnformattedCpf;
    public string FormattedCpf => Cpf.FormattedCpf;
    public string MaskedCpf => Cpf.MaskedCpf;
    #endregion

    public Person(Name name, DateOnly birthDate, CPF cpf)
    {
        Name = name;
        Cpf = cpf;

        ValidateAge(birthDate);

        BirthDate = birthDate;
    }

    private void ValidateAge(DateOnly date)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        var age = today.Year - date.Year;

        if (date > today.AddYears(-age))
            age--;

        if (age < 18)
            throw new UnderageException();

        if (age > 120)
            throw new OveragedException();
    }
}
