using MediatR;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.GerateRefreshToken
{
    public record RefreshTokenCommand(LoginTokenRequest TokenRequest) : IRequest<Result<LoginTokenResponse>>;
}
