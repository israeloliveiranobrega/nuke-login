namespace NukeLogin.Src.Features.AccessControl.Register.DTOs
{
    public record RegisterUserResponse(Guid UserId, string Name, string EmailSecret);
}
