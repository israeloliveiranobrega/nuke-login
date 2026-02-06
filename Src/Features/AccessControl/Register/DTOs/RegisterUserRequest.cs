using NukeLogin.Src.Shared.Base_DTOs;

namespace NukeLogin.Src.Features.AccessControl.Register.DTOs
{
    public record RegisterUserRequest
    {
        public PersonDTO Person { get; set; }
        public AddressDTO Address { get; set; }
        public EmailDTO Email { get; set; }
        public PhoneDTO? Phone { get; set; }
        public string Password { get; set; }
    }
}
