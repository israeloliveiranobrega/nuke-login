using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts
{
    public interface IUserSessionRepository
    {
        Task<Guid> Create(UserSession userSession, CancellationToken cancellationToken = default);
        Task<int> RevokeById(Guid userId, Guid WhoRevoked, CancellationToken cancellationToken = default);
        Task<int> UpdateRefreshTokenAsync(Guid userId, RefreshToken refreshToken, CancellationToken cancellationToken = default);
        Task<int> RevokeRefreshTokenAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
