using Nuke_Safe_Login.Infra.Repositorys.AccessControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke_Safe_Login.Infra.Repositorys.AccessControl.Implementation
{
    public class LoginAttempt : ILoginAttempt
    {
        public Task<Guid> CreateAsync(NukeLogin.Src.Domain.Models.LoginAttempt user)
        {
            throw new NotImplementedException();
        }
    }
}
