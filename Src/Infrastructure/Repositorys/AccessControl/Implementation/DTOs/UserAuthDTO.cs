using NukeLogin.Src.Domain.ValueObjects.Base.Enums;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs
{
    public record UserAuthDTO(
        Guid Id,
        string FirsName, 
        string LastName, 
        string EmailAddress, 
        string EmailDomain, 
        string Cpf, 
        string PasswordHash, 
        AccountStatus Status);
}
