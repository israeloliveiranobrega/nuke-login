using NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
using NukeLogin.Src.UseCases.Extension;
using static NukeLogin.Src.UseCases.Extension.StringExtensionHelper;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base;
public record Name
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string FullName => $"{FirstName} {LastName}";

    public Name(string firstName, string lastName)
    {
        ValidateNamePart(firstName);
        ValidateNamePart(lastName);

        FirstName = firstName;
        LastName = lastName;
    }

    private void ValidateNamePart(string namePart)
    {
        if (!namePart.HasContent() || !namePart.HasMinLength(3))
            throw new InvalidNameLengthExceptions(nameof(namePart));

        if (!namePart.IsOnlyLettersOrNumbers(CheckType.OnlyLetters))
            throw new InvalidNameCharacterExceptions(nameof(namePart));
    }
}
