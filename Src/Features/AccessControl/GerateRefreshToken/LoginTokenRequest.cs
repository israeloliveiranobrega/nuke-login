using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;

namespace NukeLogin.Src.Features.AccessControl.GerateRefreshToken
{
    public record LoginTokenRequest(UserAuthDTO UserAuth);
}
