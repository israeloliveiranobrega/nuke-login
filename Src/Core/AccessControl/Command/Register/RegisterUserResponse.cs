namespace NukeLogin.Src.Core.AccessControl.Command.Register
{
    public record RegisterUserResponse(Guid UserId, string Name, string EmailSecret);
}
