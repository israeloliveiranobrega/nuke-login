using MediatR;

namespace NukeLogin.Src.Core.AccessControl.Command.Register;
public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public RegisterUserHandler()
    {

    }

    public Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = request;

        throw new NotImplementedException();
    } 
}
