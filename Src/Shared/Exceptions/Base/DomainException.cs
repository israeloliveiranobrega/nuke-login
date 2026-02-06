namespace NukeLogin.Src.Shared.Exceptions.Base;
public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }
}
