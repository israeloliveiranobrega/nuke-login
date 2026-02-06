using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;

namespace NukeLogin.Src.Features.AccessControl.JasonWebToken
{
    public interface IJwtProvider
    {
        Task<string> GerateToken(UserAuthDTO user);
        Task<string> GerateRefreshToken();
    }
}
