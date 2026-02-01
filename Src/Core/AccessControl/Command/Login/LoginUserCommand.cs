using MediatR;

namespace NukeLogin.Src.Core.AccessControl.Command.Login
{
    public record LoginUserCommand (string Cpf, string Password): IRequest<LoginUserResponse>;
}
