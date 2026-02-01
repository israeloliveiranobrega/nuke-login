namespace NukeLogin.Src.Domain.Models.Base.Exceptions;
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }
}
