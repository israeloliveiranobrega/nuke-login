namespace NukeLogin.Src.Features.AccessControl.Login
{
    public record LoginUserRequest(string? Cpf, string? EmailAddress, string? EmailDomain, string Password, bool LoginWithEmail = false);
}
