using NukeLogin.Src.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke_Safe_Login.Infra.Repositorys.AccessControl.Contracts
{
    public interface ISessionRepository
    {
        Task<Guid> CreateAsync(UserSession user);
        Task<bool?> RevokeByUserId(Guid userId);
    }
}
