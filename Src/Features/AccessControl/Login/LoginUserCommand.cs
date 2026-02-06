using MediatR;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.Login
{
    public record LoginUserCommand (LoginUserRequest LoginRequest, UserAgentInfo UserAgent) : IRequest<Result<LoginUserResponse>>;
}
