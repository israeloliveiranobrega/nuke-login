using Nuke_Safe_Login.Infra.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke_Safe_Login.Infra.Repositorys.AccessControl.Implementation
{
    public class SessionRepository : ISessionRepository
    {
        public Task<Guid> CreateAsync(UserSession user)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> RevokeByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
