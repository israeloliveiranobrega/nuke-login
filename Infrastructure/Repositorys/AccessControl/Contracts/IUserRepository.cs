using NukeLogin.Src.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke_Safe_Login.Infra.Repositorys.AccessControl.Contracts
{
    public interface IUserRepository
    {
        Guid Create(LoginAttempt user);
        bool? DeleteById(Guid userId);
        bool Update(LoginAttempt user);
    }
}
