using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation
{
    public class UserSessionRepository(DataContext dataContext) : IUserSessionRepository
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly DbSet<UserSession> _session = dataContext.UserSessions;
    
        public async Task<int> UpdateRefreshTokenAsync(Guid userId, RefreshToken refreshToken, CancellationToken cancellationToken = default)
        {
            return await _session
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(u => u.RefreshToken.Code, refreshToken.Code)
                    .SetProperty(u => u.RefreshToken.ExpiresOn, refreshToken.ExpiresOn),
                    cancellationToken);
        }
        public async Task<int> RevokeRefreshTokenAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _session
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(u => u.RefreshToken.Code, string.Empty)
                    .SetProperty(u => u.RefreshToken.ExpiresOn, null),
                    cancellationToken);
        }

        public async Task<Guid> Create(UserSession userSession, CancellationToken cancellationToken = default)
        {
            await _session.AddAsync(userSession, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return userSession.Id;
        }

        public Task<int> RevokeById(Guid userId, Guid WhoRevoked, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
