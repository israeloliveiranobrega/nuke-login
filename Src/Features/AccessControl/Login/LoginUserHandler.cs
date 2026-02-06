using MediatR;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Features.AccessControl.JasonWebToken;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.Login;
public class LoginUserHandler(IUserRepository userRepository, IJwtProvider jwtPreovider, IUserSessionRepository userSessionRepository) : IRequestHandler<LoginUserCommand, Result<LoginUserResponse>>
{
    public async Task<Result<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        #region Validations
        UserAuthDTO userAuth;

        if(request.UserAgent.SpiderOrBot == true)
            return Result<LoginUserResponse>.Failure("Login por robôs não permitido.");

        if (request.LoginRequest.LoginWithEmail)
        {
            if (!await userRepository.ExistsByEmailAsync(request.LoginRequest.EmailAddress, request.LoginRequest.EmailDomain, cancellationToken))
                return Result<LoginUserResponse>.Failure("Email não cadastrado.");

            userAuth = await userRepository.GetUserAuthByEmailAsync(request.LoginRequest.EmailAddress, request.LoginRequest.EmailDomain, cancellationToken);
        }
        else
        {
            if (!await userRepository.ExistsByCpfAsync(request.LoginRequest.Cpf, cancellationToken))
                return Result<LoginUserResponse>.Failure("Cpf não cadastrado.");

            userAuth = await userRepository.GetUserAuthByCpfAsync(request.LoginRequest.Cpf, cancellationToken);
        }
        #endregion

        if (!Password.Validate(request.LoginRequest.Password, userAuth.PasswordHash))
            return Result<LoginUserResponse>.Failure("Senha incorreta.");

        var accessToken = await jwtPreovider.GerateToken(userAuth);
        var refreshToken = await jwtPreovider.GerateRefreshToken();

        var tokenVo = new RefreshToken(refreshToken, DateTime.UtcNow.AddDays(7));
        var session = new UserSession(userAuth.Id,request.UserAgent, tokenVo);

        var sessionId = await userSessionRepository.Create(session, cancellationToken);

        return Result<LoginUserResponse>.Success(new LoginUserResponse(sessionId,userAuth.Id,accessToken,refreshToken));
    }
}
