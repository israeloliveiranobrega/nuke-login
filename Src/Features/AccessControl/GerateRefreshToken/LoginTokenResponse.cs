using MediatR;
using NukeLogin.Src.Domain.ValueObjects.Base;

namespace NukeLogin.Src.Features.AccessControl.GerateRefreshToken
{
    public record LoginTokenResponse(string TokenAccess, RefreshToken RefreshToken);
}
