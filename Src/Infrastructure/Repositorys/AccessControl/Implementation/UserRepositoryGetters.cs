using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base.Enums;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation
{
    public partial class UserRepository
    {
        #region Existence checkers
        public Task<bool> ExistsByEmailAsync(string address, string domain, CancellationToken cancellationToken = default)
        {
            return _user
               .AsNoTracking()
               .AnyAsync(x => x.Email.Address == address && x.Email.Domain == domain, cancellationToken);
        }
        public Task<bool> ExistsByCpfAsync(string cpf, CancellationToken cancellationToken = default)
        {
            var test = _user
                .AsNoTracking()
                .AnyAsync(user => user.Person.Cpf.UnformattedCpf == cpf, cancellationToken);

            return test;
        }
        public Task<bool> ExistsByPhoneAsync(ulong countryCode, ulong number, CancellationToken cancellationToken = default)
        {
            return _user
                .AsNoTracking()
                .AnyAsync(u => u.Phone.CountryCode == countryCode && u.Phone.Number == number, cancellationToken);
        }
        #endregion

        public Task<UserAuthDTO?> GetUserAuthByEmailAsync(string address, string domain, CancellationToken cancellationToken = default)
        {
            return _user
                .AsNoTracking()
                .Where(u => u.Email.Address == address && u.Email.Domain == domain)
                .Select(u => new UserAuthDTO(
                    u.Id,
                    u.Person.FirstName,
                    u.Person.LastName,
                    u.Email.Address,
                    u.Email.Domain,
                    u.Person.Cpf.UnformattedCpf,
                    u.Password.Hash,
                    u.Status))
                .FirstOrDefaultAsync(cancellationToken);
            throw new NotImplementedException();
        }
        public Task<UserAuthDTO?> GetUserAuthByCpfAsync(string cpf, CancellationToken cancellationToken = default)
        {
            return _user
                .AsNoTracking()
                .Where(u => u.Person.Cpf.UnformattedCpf == cpf)
                .Select(u => new UserAuthDTO(
                    u.Id,
                    u.Person.FirstName,
                    u.Person.LastName,
                    u.Email.Address,
                    u.Email.Domain,
                    u.Person.Cpf.UnformattedCpf,
                    u.Password.Hash,
                    u.Status))
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<User?> GetUserByEmailAsync(string address, string domain, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<User?> GetUserByCpfAsync(string cpf, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<AccountStatus?> GetStatusAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
