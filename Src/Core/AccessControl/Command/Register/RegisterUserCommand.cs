using MediatR;
using NukeLogin.Src.Core.DTOs;
using NukeLogin.Src.Core.DTOs.Base;


namespace NukeLogin.Src.Core.AccessControl.Command.Register
{
    public record RegisterUserCommand(PersonDTO Person, AdressDTO Adress,PhoneDTO Phone, EmailDTO Email, string Password) : IRequest<RegisterUserResponse>;
}
