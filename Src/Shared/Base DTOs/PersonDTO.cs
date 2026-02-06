using NukeLogin.Src.Domain.ValueObjects.Base;

namespace NukeLogin.Src.Shared.Base_DTOs
{
    public class PersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Cpf { get; set; }
    }
}
