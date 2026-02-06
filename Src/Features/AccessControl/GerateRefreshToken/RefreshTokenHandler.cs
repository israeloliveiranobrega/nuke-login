using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Domain.ValueObjects.Base.Enums;
using NukeLogin.Src.Features.AccessControl.JasonWebToken;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.GerateRefreshToken
{
    public class RefreshTokenHandler(IUserRepository userRepository, IUserSessionRepository userSessionRepository, IJwtProvider jwtPreovider) : IRequestHandler<RefreshTokenCommand, Result<LoginTokenResponse>>
    {
        public async Task<Result<LoginTokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            AccountStatus? accountStatus = await userRepository.GetStatusAsync(request.TokenRequest.UserAuth.Id, cancellationToken);

            if (accountStatus is null)
                return Result<LoginTokenResponse>.Failure("Usuário não encontrado.");

            if(accountStatus != AccountStatus.Active)
                return Result<LoginTokenResponse>.Failure("Usuário não está ativo.");

            var token = await jwtPreovider.GerateToken(request.TokenRequest.UserAuth);
            var refreshToken = await jwtPreovider.GerateRefreshToken();

            RefreshToken newRefresh = new(refreshToken, DateTime.UtcNow.AddDays(7));

            await userSessionRepository.UpdateRefreshTokenAsync(request.TokenRequest.UserAuth.Id, newRefresh, cancellationToken);

            return Result<LoginTokenResponse>.Success(new(token, newRefresh));
        }
    }
}
