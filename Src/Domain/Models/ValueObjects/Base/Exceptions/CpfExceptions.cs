using NukeLogin.Src.Domain.Models.Base.Exceptions;

namespace NukeLogin.Src.Domain.Models.ValueObjects.Base.Exceptions;
public class InvalidCpfException : DomainException
{
    public InvalidCpfException() : base ("Cpf é matematicamente inválido.") { }
}
public class KnowInvalidCpfException : DomainException
{
    public KnowInvalidCpfException() : base ("Cpf é um inválido conhecido.") { }
}
public class InvalidCpfFormatException : DomainException
{
    public InvalidCpfFormatException() : base ("O Cpf deve conter apenas números e ter 11 digitos.") { }
}
