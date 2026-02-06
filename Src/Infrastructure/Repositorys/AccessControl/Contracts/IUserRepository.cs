using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Domain.ValueObjects.Base.Enums;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;
using System.Threading;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts
{
    public interface IUserRepository
    {
        Task<Guid> Create(User user, CancellationToken cancellationToken = default);
        Task<bool> ExistsByEmailAsync(string address, string domain, CancellationToken cancellationToken = default);
        Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken = default);
        Task<bool> ExistsByPhoneAsync(ulong countryCode, ulong number, CancellationToken cancellationToken = default);

        Task<UserAuthDTO?> GetUserAuthByEmailAsync(string address, string domain, CancellationToken cancellationToken = default);
        Task<UserAuthDTO?> GetUserAuthByCpfAsync(string cpf, CancellationToken cancellationToken = default);

        Task<User?> GetUserByEmailAsync(string address, string domain, CancellationToken cancellationToken = default);
        Task<User?> GetUserByCpfAsync(string cpf, CancellationToken cancellationToken = default);

        Task<AccountStatus?> GetStatusAsync(Guid userId, CancellationToken cancellationToken = default);

        Task<int> Change(User user, Guid whoEdited, CancellationToken cancellationToken = default);
        Task<int> Delete(User user, Guid whoEdited, CancellationToken cancellationToken = default);
        Task<int> Suspend(User user, Guid whoEdited, CancellationToken cancellationToken = default);
        Task<int> Active(User user, Guid whoEdited, CancellationToken cancellationToken = default);
    }
}
