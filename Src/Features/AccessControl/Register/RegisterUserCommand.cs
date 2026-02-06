using MediatR;
using NukeLogin.Src.Features.AccessControl.Register.DTOs;
using NukeLogin.Src.Shared;

namespace NukeLogin.Src.Features.AccessControl.Register
{
    public record RegisterUserCommand(RegisterUserRequest RegisterRequest, Guid? WhoCriated) : IRequest<Result<RegisterUserResponse>>;
}           
