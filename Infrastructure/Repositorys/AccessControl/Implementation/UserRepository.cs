using Nuke_Safe_Login.Domain.Models;
using Nuke_Safe_Login.Infra.Repositorys.AccessControl.Contracts;
using NukeLogin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuke_Safe_Login.Infra.Repositorys.AccessControl.Implementation
{
    public class UserRepository(DataContext database) 
    {
        public readonly DataContext _database = database;
        public Guid Create(LoginAttempt user)
        {
            throw new NotImplementedException();
        }

        public bool? DeleteById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(LoginAttempt user)
        {
            throw new NotImplementedException();
        }
    }
}
