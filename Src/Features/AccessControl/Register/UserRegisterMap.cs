using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Features.AccessControl.EmailVerifications;
using NukeLogin.Src.Features.AccessControl.Register.DTOs;

namespace NukeLogin.Src.Features.AccessControl.Register
{
    public static class UserRegisterMap
    {
        public static User ToEntity(this RegisterUserRequest request)
        {
            Person person = new(new(request.Person.FirstName, request.Person.LastName),
                request.Person.BirthDate,new(request.Person.Cpf));

            Address address = new(request.Address.ZipCode,
                request.Address.Region,
                request.Address.State,
                request.Address.City,
                request.Address.Neighborhood,
                request.Address.Street,
                request.Address.Number,
                request.Address.Complement);

            Email email = new(request.Email.Address, request.Email.Domain);
            Phone phone = new(request.Phone.CountryCode, request.Phone.Number);

            Password password = new(request.Password);

            return new User(person, address, email, password, phone);
        }
        //public static RegisterUserCommand ToCommand()
        //{

        //}

    }
}
